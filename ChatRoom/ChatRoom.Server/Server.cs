using System.Net;

namespace ChatRoom.Server;

public class Server
{
    public string Name { get; set; }
    public int Port { get; set; } = 1433;
    public IPHostEntry HostEntry { get; set; }
    public IPAddress ServerIpAddress { get; set; }
}