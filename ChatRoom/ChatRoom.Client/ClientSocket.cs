using System.Net.Sockets;
using System.Net;
using System.Text;

namespace ChatRoom.Client;

public class ClientSocket
{
    public Client Client { get; set; }
    public Socket SocketClient { get; set; }

    public ClientSocket()
    {
        
    }

    public ClientSocket(Client client)
    {
        Client = client;
    }
    public void StartConnection()
    {
        try
        {
            IPHostEntry hosts = Dns.GetHostEntry(Dns.GetHostName());
            
            Client.ServerIpAddress = hosts.AddressList[0];
            
            IPEndPoint localEndPoint = new IPEndPoint(Client.ServerIpAddress, Client.Port);
            
            // TODO: Fix local endpoint connectivity
            // labels: bug
            
            SocketClient = new Socket(Client.ServerIpAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            
            SocketClient.Connect(localEndPoint);

            if (SocketClient.Connected)
                Console.WriteLine("Socket connected to " + SocketClient.RemoteEndPoint);
            else
            {
                Console.WriteLine("Connection failed, retrying...");
                StartConnection();
            }
                
        }
        catch (Exception e)
        {
            // TODO: Add exception handle
        }
    }

    public void StopConnection()
    {
        SocketClient.Close();
    }

    public string SendMessage(string message)
    {
        byte[] byteMessage = Encoding.ASCII.GetBytes(message);
        SocketClient.Send(byteMessage);

        return ReceiveMessage();
    }

    public string ReceiveMessage()
    {
        byte[] messageBuffer = new byte[1024];
        int byteCount = SocketClient.Receive(messageBuffer);
        
        return Encoding.ASCII.GetString(messageBuffer, 0, byteCount);
    }
}