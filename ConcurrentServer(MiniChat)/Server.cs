using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrentServer_MiniChat_
{
    public class Server
    {
        public void Start()
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, 7070);
            server.Start();

            using (TcpClient socket = server.AcceptTcpClient())
            using (NetworkStream ns = socket.GetStream())
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {
                string streamInputLine="";
                string myLine="";

                while ((streamInputLine!="STOP") || (myLine!="STOP"))
                {
                    streamInputLine = sr.ReadLine();
                    Console.WriteLine("Server StreamInputLine: "+ streamInputLine);
                    Console.WriteLine("Skriv en tekst: ");
                    myLine = Console.ReadLine();
                    sw.WriteLine(myLine);
                    sw.Flush();
                }
            }

        }
    }
}
