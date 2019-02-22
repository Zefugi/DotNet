using System;
using System.Net;
using System.Net.Sockets;

namespace Zefugi.DotNet.Net
{
    public static class DnsResolver
    {
        public static bool ResolveOrParse(
            string hostNameOrAddress, int port, AddressFamily addressFamily,
            out IPEndPoint endPoint)
        {
            IPAddress ip = null;
            IPAddress[] list;

            // Parse
            if (IPAddress.TryParse(hostNameOrAddress, out ip))
            {
                endPoint = new IPEndPoint(ip, port);
                return true;
            }

            // Resolve
            try { list = Dns.GetHostEntry(hostNameOrAddress).AddressList; }
            catch
            {
                endPoint = null;
                return false;
            }
            foreach (IPAddress entry in list)
            {
                if (entry.AddressFamily == addressFamily)
                {
                    endPoint = new IPEndPoint(entry, port);
                    return true;
                }
            }
            endPoint = null;
            return false;
        }
    }
}
