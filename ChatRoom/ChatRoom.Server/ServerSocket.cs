using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ChatRoom.Server;

public class ServerSocket
{
    public Server Server { get; set; }

    public IPEndPoint EndPoint { get; set; }
    
    public Socket SocketServer { get; set; }

    public ServerSocket()
    {
        
    }

    public ServerSocket(Server server)
    {
        Server = server;
    }
    
    public void StartServer()
    {
        Server.HostEntry = Dns.GetHostEntry(Dns.GetHostName());

        Server.ServerIpAddress = Server.HostEntry.AddressList[0];

        EndPoint = new IPEndPoint(Server.ServerIpAddress, Server.Port);
        
        // TODO: Fix connection interrupt
        // Unhandled exception. System.Net.Sockets.SocketException (10061): No connection could be made because the target machine actively refused it.

        SocketServer = new Socket(Server.ServerIpAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        
        SocketServer.Connect(EndPoint);

        if (SocketServer.Connected)
        {
            Console.WriteLine("Server socket connected to " + SocketServer.RemoteEndPoint);
        }
        else
        {
            StartServer();
        }
    }

    public void StopServer()
    {
        SocketServer.Shutdown(SocketShutdown.Both);
        SocketServer.Close();
    }

    public void BroadcastMessage(string message)
    {
        byte[] encodedMessage = Encoding.ASCII.GetBytes(message);

        SocketServer.Send(encodedMessage);
    }

    public string ReceiveMessage()
    {
        byte[] buffer = new byte[1024];
        
        int bytesReceived = SocketServer.Receive(buffer);

        return Encoding.ASCII.GetString(buffer, 0, bytesReceived);
    }

}