using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LeTrinhHoangAnhTien_buoi9
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient();

            string log = "";

            client.Connect("mail.emailserver.vn", 25);

            StreamReader sr = new StreamReader(client.GetStream());
            StreamWriter sw = new StreamWriter(client.GetStream());

            log += "Server: " + sr.ReadLine() + "\n";

            string data = "HELO";

            log += "Client: " + data + "\n";
            sw.WriteLine(data);
            sw.Flush();

            log += "Server: " + sr.ReadLine() + "\n";
            data = "MAIL FROM: <" + "nguyxxdoxxphoxx.it@gmail.com" + ">";
            log += "Client: " + data + "\n";
            sw.WriteLine(data);
            sw.Flush();
            log += "Server: " + sr.ReadLine() + "\n";
            data = "RCPT TO: <" + "phong.nd@emailserver.vn" + ">";
            log += "Client: " + data + "\n";
            sw.WriteLine(data);
            sw.Flush();
            log += "Server: " + sr.ReadLine() + "\n";
            data = "DATA";
            log += "Client: " + data + "\n";
            sw.WriteLine(data);
            sw.Flush();
            log += "Server: " + sr.ReadLine() + "\n";
            data = emailContent + "\r\n" + ".";
            log += "Client: " + data + "\n";
            sw.WriteLine(data);
            sw.Flush();
            log += "Server: " + sr.ReadLine() + "\n";
            data = "QUIT";
            log += "Client: " + data + "\n";
            sw.WriteLine(data);
            sw.Flush();
            log += "Server: " + sr.ReadLine() + "\n";     
            sr.Close();
            sw.Close();
            client.Close();
        }
        public static string emailContent { get; set; }
    }
}
