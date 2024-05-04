using System.Net;

namespace ChatRoom.Client;

public class Client
{
    public string Name { get; set; } = null;
    public IPAddress ServerIpAddress { get; set; }
    public int Port { get; set; }
    
}