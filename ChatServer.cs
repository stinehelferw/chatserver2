using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Threading;

namespace ChatServer
{
    public class ChatServer
    {
        private static ChatServer ChatServerInstance;
        static readonly object padlock = new object();

        private ChatServer()
        {

        }
        public static ChatServer GetInstance()
        {
            lock (padlock)
            {
                if (ChatServerInstance == null)
                {
                    ChatServerInstance = new ChatServer();
                }
                return ChatServerInstance;
            }
        }

        List<Thread> list = new List<Thread>();

        private IPAddress localAddr = IPAddress.Parse("127.0.0.1");
        private Int32 port = 2223;

        public void serverListen()
        {
            TcpListener tcpListener = new TcpListener(localAddr, port);
            tcpListener.Start();

            TcpClient tcpClient = tcpListener.AcceptTcpClient();

        }
    }
}
