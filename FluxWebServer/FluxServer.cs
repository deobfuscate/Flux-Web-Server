using System;
using System.Collections.Generic;
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
        Dictionary<string, string> mimeTypes = new Dictionary<string, string>(){
            {".zip", "application/zip"},
            {".jpg", "image/jpeg"},
            {".png", "image/png"},
            {".gif", "image/gif"},
            {".mp4", "video/mp4"},
            {".webm", "video/webm"},
            {".flv", "video/x-flv"},
            {".html", "text/html"},
            {".htm", "text/html"}
        };

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
            List<string> modes = new List<string> { "GET", "POST", "PUT", "HEAD", "DELETE" };
            if (StartsWithLst(modes, data))
            {
                string[] strDataW = data.Split(new char[] { ' ' });
                string strFilePath = strDataW[1];
                OnLogMessage(new LogMessageEventArgs($"\"{strDataW[0]} {strDataW[1]}\" from {tcpClient.Client.RemoteEndPoint}"));
                byte[] bHeader;

                if (strFilePath.Substring(Math.Max(0, strFilePath.Length - 4)) == ".php")
                {
                    string phpResult = ExecPHP(path + strFilePath, strFilePath);
                    string[] words = phpResult.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.None);
                    string headers = words.First();
                    string content = string.Join("\r\n\r\n", words.Skip(1));
                    bContent = Encoding.UTF8.GetBytes(content);
                    if (headers.Contains("Location: "))
                        bHeader = Encoding.UTF8.GetBytes($"HTTP/1.1 302 FOUND\r\n{headers}\r\nContent-Length: {bContent.Length}\r\n\r\n");
                    else
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
                        {
                            bContent = Encoding.UTF8.GetBytes(ReadEmbeddedFile("404.html"));
                            OnLogMessage(new LogMessageEventArgs($"Error: 404 Cannot find {strFilePath}"));
                        }
                        else
                        {
                            bContent = Encoding.UTF8.GetBytes(ReadEmbeddedFile("error.html"));
                            OnLogMessage(new LogMessageEventArgs($"Error: {ex}"));
                            return;
                        }
                    }
                    string contentType;
                    if (mimeTypes.ContainsKey(GetExt(strFilePath)))
                        contentType = mimeTypes[GetExt(strFilePath)];
                    else
                        contentType = "text/html";
                    bHeader = Encoding.UTF8.GetBytes($"HTTP/1.1 200 OK\r\nContent-Type: {contentType}; charset=UTF-8\r\nContent-Length: {bContent.Length}\r\n\r\n");
                }

                nsInput.Write(bHeader, 0, bHeader.Length);
                nsInput.Write(bContent, 0, bContent.Length);
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

        public static string GetExt(string url)
        {
            url = url.Split('?')[0].Split('/').Last();
            return url.Contains('.') ? url.Substring(url.LastIndexOf('.')) : "";
        }

        public static string ExecPHP(string file, string path)
        {
            Process procPHP = new Process();
            procPHP.StartInfo.UseShellExecute = false;
            procPHP.StartInfo.EnvironmentVariables["REDIRECT_STATUS"] = "CGI";
            procPHP.StartInfo.EnvironmentVariables["SCRIPT_NAME"] = path;
            procPHP.StartInfo.RedirectStandardOutput = true;
            procPHP.StartInfo.CreateNoWindow = true;
            procPHP.StartInfo.FileName = "php\\php-cgi.exe";
            procPHP.StartInfo.Arguments = file;
            procPHP.Start();
            string phpResult = procPHP.StandardOutput.ReadToEnd();
            procPHP.WaitForExit();
            return phpResult;
        }

        private bool StartsWithLst(List<string> list, string start)
        {
            foreach (string str in list)
                if (start.StartsWith(str))
                    return true;
            return false;
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