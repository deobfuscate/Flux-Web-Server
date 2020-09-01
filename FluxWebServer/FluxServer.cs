using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;

namespace FluxWebServer
{
    class FluxServer
    {
        private int port;
        private string path;
        private TcpListener tcpListener;
        private bool stoppingListener;
        public event EventHandler<LogMessageEventArgs> LogMessage;

        public FluxServer(int port, string path)
        {
            this.port = port;
            this.path = path;
        }

        public bool Start()
        {
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, port);
                tcpListener.Start();
            }
            catch (SocketException ex)
            {
                if (ex.ErrorCode == 10048)
                    OnLogMessage(new LogMessageEventArgs("Error: Address is already in use, ensure that the port is open."));
                else
                    OnLogMessage(new LogMessageEventArgs($"Error: {ex.ToString()}"));
                return false;
            }

            tcpListener.BeginAcceptTcpClient(ManageClient, tcpListener);
            return true;
        }

        public void Stop()
        {
            stoppingListener = true;
            tcpListener.Stop();
        }

        private void ManageClient(IAsyncResult iarStatus)
        {
#if DEBUG
            Console.WriteLine("=== Incoming connection");
#endif
            if (stoppingListener)
            {
                stoppingListener = false;
                Console.WriteLine("WE STOPPIN");
                return;
            }
            byte[] bContent;
            tcpListener = (TcpListener) iarStatus.AsyncState;
            var tcpClient = tcpListener.EndAcceptTcpClient(iarStatus);
            tcpListener.BeginAcceptTcpClient(ManageClient, tcpListener);
            NetworkStream nsInput = tcpClient.GetStream();
            byte[] bInput = new byte[tcpClient.Available];
            nsInput.Read(bInput, 0, tcpClient.Available);
            string data = Encoding.UTF8.GetString(bInput);
#if DEBUG
            Console.WriteLine($"<-- '{data}' from {tcpClient.Client.Handle} Len: {tcpClient.Available} bytes");
#endif
            if (new System.Text.RegularExpressions.Regex("^GET").IsMatch(data))
            {
                string[] strDataW = data.Split(new char[] { ' ' });
                string strFilePath = strDataW[1];
                OnLogMessage(new LogMessageEventArgs($"\"{strDataW[0]} {strDataW[1]}\" from {tcpClient.Client.RemoteEndPoint}"));
                byte[] bHeader;

                if (strFilePath.Substring(Math.Max(0, strFilePath.Length - 4)) == ".php")
                {
                    Process procPHP = new Process();
                    procPHP.StartInfo.UseShellExecute = false;
                    procPHP.StartInfo.RedirectStandardOutput = true;
                    procPHP.StartInfo.CreateNoWindow = true;
                    procPHP.StartInfo.FileName = "C:\\Users\\Home\\Documents\\Apps\\php\\php-cgi.exe";
                    procPHP.StartInfo.Arguments = path + strFilePath;
                    procPHP.Start();
                    string phpResult = procPHP.StandardOutput.ReadToEnd();
                    string[] words = phpResult.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.None);
                    string headers = words.First();
                    string content = string.Join("\r\n\r\n", words.Skip(1));
                    procPHP.WaitForExit();
                    bContent = Encoding.UTF8.GetBytes(content);
                    bHeader = Encoding.UTF8.GetBytes($"HTTP/1.1 200 OK\r\n{headers}\r\nContent-Length: {bContent.Length}\r\n\r\n");
                }
                else
                {
                    try
                    {
                        bContent = File.ReadAllBytes(path + strFilePath.Replace("/", @"\"));
                    }
                    catch (Exception ex)
                    {
                        if (ex is FileNotFoundException || ex is DirectoryNotFoundException || ex is UnauthorizedAccessException)
                            bContent = Encoding.UTF8.GetBytes(ReadEmbeddedFile("404.html"));
                        else
                        {
                            bContent = Encoding.UTF8.GetBytes(ReadEmbeddedFile("error.html"));
                            OnLogMessage(new LogMessageEventArgs($"Error: {ex}"));
                            return;
                        }
                    }
                    bHeader = Encoding.UTF8.GetBytes($"HTTP/1.1 200 OK\r\nContent-Type: text/html; charset=UTF-8\r\nContent-Length: {bContent.Length}\r\n\r\n");
                }

                byte[] bResult = JoinByteArray(bHeader, bContent);
                nsInput.Write(bResult, 0, bResult.Length);
                nsInput.Close();
            }
            tcpClient.Close();
        }

        private string ReadEmbeddedFile(string file)
        {
            string result;
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"FluxWebServer.resources.{file}"))
            using (StreamReader reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
                reader.Close();
            }
            return result;
        }

        private byte[] JoinByteArray(byte[] first, byte[] last)
        {
            byte[] bTmp = new byte[first.Length + last.Length];
            Buffer.BlockCopy(first, 0, bTmp, 0, first.Length);
            Buffer.BlockCopy(last, 0, bTmp, first.Length, last.Length);
            return bTmp;
        }
        
        protected virtual void OnLogMessage(LogMessageEventArgs e)
        {
            LogMessage?.Invoke(this, e);
        }
    }

    public class LogMessageEventArgs : EventArgs
    {
        public string Message;

        public LogMessageEventArgs(string message)
        {
            Message = message;
        }
    }
}