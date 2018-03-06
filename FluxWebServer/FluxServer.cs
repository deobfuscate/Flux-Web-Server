using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace FluxWebServer
{
    class FluxServer
    {
        private frmMain _frmMain;
        private int iPort;
        private string strDir;
        private TcpListener tcpListener;
        private bool stoppingListener;

        public FluxServer(frmMain form, int port, string directory)
        {
            _frmMain = form;
            iPort = port;
            strDir = directory;
        }

        public bool Start()
        {
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, 80);
                tcpListener.Start();
            }
            catch (SocketException ex)
            {
                if (ex.ErrorCode == 10048)
                {
                    _frmMain.Log("Error: Address is already in use, ensure that the port is open");
                }
                else
                {
                    _frmMain.Log("Error:" + ex.ToString());
                }
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
            if (stoppingListener)
            {
                stoppingListener = false;
                return;
            }
            byte[] bContent;
            tcpListener = (TcpListener) iarStatus.AsyncState;
            var tcpClient = tcpListener.EndAcceptTcpClient(iarStatus);
            tcpListener.BeginAcceptTcpClient(ManageClient, tcpListener);
            
            byte[] bInput = new byte[tcpClient.Available];
            NetworkStream nsInput = tcpClient.GetStream();
            nsInput.Read(bInput, 0, bInput.Length);
            string strData = Encoding.UTF8.GetString(bInput);
            if (new System.Text.RegularExpressions.Regex("^GET").IsMatch(strData))
            {
                string[] strDataW = strData.Split(new char[] { ' ' });
                string strFilePath = strDataW[1];
                _frmMain.Log("\"" + strDataW[0] + " "+ strDataW[1] + "\" from " + tcpClient.Client.RemoteEndPoint.ToString());
                try
                {
                    bContent = File.ReadAllBytes(strDir + strFilePath.Replace("/", @"\"));
                }
                catch (Exception ex)
                {
                    if (ex is FileNotFoundException || ex is DirectoryNotFoundException || ex is UnauthorizedAccessException)
                    {
                        bContent = Encoding.UTF8.GetBytes("<html><head><title>404</title></head><body><p>404 Not Found</p></body></html>");
                    }
                    else
                    {
                        bContent = Encoding.UTF8.GetBytes("<html><head><title>Error</title></head><body><p>An error has occured.</p></body></html>");
                        _frmMain.Log("Error: " + ex);
                        return;
                    }
                }

                byte[] bHeader = Encoding.UTF8.GetBytes("HTTP/1.1 200 OK\r\n"
                    + "Content-Length: " + bContent.Length + "\r\n\r\n"
                    );
                byte[] bResult = JoinByteA(bHeader, bContent);
                nsInput.Write(bResult, 0, bResult.Length);
                nsInput.Close();
            }
            tcpClient.Close();
        }

        private byte[] JoinByteA(byte[] bFirst, byte[] bLast)
        {
            byte[] bTmp = new byte[bFirst.Length + bLast.Length];
            Buffer.BlockCopy(bFirst, 0, bTmp, 0, bFirst.Length);
            Buffer.BlockCopy(bLast, 0, bTmp, bFirst.Length, bLast.Length);
            return bTmp;
        }
    }
}
