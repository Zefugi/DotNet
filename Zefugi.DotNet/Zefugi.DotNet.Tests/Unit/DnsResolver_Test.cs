using System;
using System.Net;
using System.Net.Sockets;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Zefugi.DotNet.Net;

namespace Zefugi.DotNet.Tests.Unit
{
    [TestClass]
    public class DnsResolver_Test
    {
        [TestMethod]
        public void ResolveLocalhost()
        {
            Assert.IsTrue(DnsResolver.ResolveOrParse("localhost", 1337, AddressFamily.InterNetwork, out IPEndPoint ep));
            Assert.AreEqual(AddressFamily.InterNetwork, ep.AddressFamily);
            Assert.AreEqual(IPAddress.Parse("127.0.0.1"), ep.Address);
            Assert.AreEqual(1337, ep.Port);
        }
    }
}
