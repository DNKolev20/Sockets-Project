using System.Net;
using System.Net.Sockets;
using System.Threading.Channels;

namespace ChatRoom.Client;

public class Client
{
    public string Name { get; set; } = null;
    public IPAddress ClientIpAddress { get; set; }
    public int Port { get; set; }
    private Socket _clientSocket;

    public void StartConnection()
    {
        try
        {
            IPHostEntry hosts = Dns.GetHostEntry(Dns.GetHostName());
            
            ClientIpAddress = hosts.AddressList[0];
            
            IPEndPoint localEndPoint = new IPEndPoint(ClientIpAddress, Port);
            
            _clientSocket = new Socket(ClientIpAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            
            _clientSocket.Connect(localEndPoint);

            if (_clientSocket.Connected)
                Console.WriteLine("Socket connected to " + _clientSocket.RemoteEndPoint.ToString());
            else
                StartConnection();
        }
        catch (Exception e)
        {
            // TODO: Add exception handle
        }
    }

    public void StopConnection()
    {
        // TODO: Add StopConnection method
    }

    public void SendMessage()
    {
        // TODO: Add SendMessage method
    }

    public void ReceiveMessage()
    {
        // TODO: Add ReceiveMessage method
    }
}