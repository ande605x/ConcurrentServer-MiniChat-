using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MiniChatClient
{
    public class Client
    {
        public void Start()
        {
            using (TcpClient socket = new TcpClient("localhost", 7070))
            using (NetworkStream ns = socket.GetStream())
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {

                string clientLine = "";
                string clientStreamReadLine = "";



                while (((clientLine != "STOP") || (clientStreamReadLine != "STOP")))
                {
                    Console.WriteLine("Client:");
                    Console.WriteLine("Indtast tekst: ");
                    clientLine = Console.ReadLine();
                    sw.WriteLine(clientLine);
                    sw.Flush();

                    clientStreamReadLine = sr.ReadLine();
                    Console.WriteLine("clientStreamReadLine: "+ clientStreamReadLine);
                    
                }
            }
        }
    }
}
