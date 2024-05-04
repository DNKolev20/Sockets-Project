namespace ChatRoom.Server;

public class RunServer
{
    public static void Main(string[] args)
    {
        Server server = new Server();

        ServerSocket serverSocket = new ServerSocket(server);
        
        serverSocket.StartServer();

        string clientMessage;
        
        while (true)
        {
            clientMessage = serverSocket.ReceiveMessage();
            
            serverSocket.BroadcastMessage($"Server received \"{clientMessage}\"");
        }
    }
}