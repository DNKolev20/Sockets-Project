using System.Text;

namespace ChatRoom.Client;

public class RunClient
{
    public static void Main(string[] args)
    {
        Client client = new Client()
        {
            Name = "Something",
            Port = 1433
        };

        ClientSocket clientSocket = new ClientSocket(client);
        
        clientSocket.StartConnection();

        string message;

        while (true)
        {
            message = Console.ReadLine();

            Console.WriteLine(clientSocket.SendMessage(message));
        }
    }
}