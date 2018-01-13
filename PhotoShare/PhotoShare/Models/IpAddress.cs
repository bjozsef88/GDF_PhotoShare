using System.Net;
using System.Net.Sockets;

namespace PhotoShare.Models
{
    public class IpAddress
    {
        public string GetCurrent()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "IP Address cannot be found!";
        }
    }
}