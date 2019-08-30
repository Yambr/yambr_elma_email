using Yambr.ELMA.Email.Common.Enums;

namespace Yambr.ELMA.Email.Common.Models
{

    public class Server : IServer
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public bool UseSsl { get; set; }
        public ConnectionType ConnectionType { get; set; }
    }
}