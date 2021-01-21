import java.io.*; 
import java.net.*;

/**

@author Brianna Muleski
*/
class Server 
{    
    final int PORT = 5764;
    
    /**
    Creates a new server and runs the server. Catches any exceptions from
    the command line arguments and prints the error to the console.
    @param argv command line arguments
    */
    public static void main(String argv[])    
    {
        try
        {
            Server serv = new Server();
            serv.run();
        }
        catch (Exception e)
        {
            System.out.println("Exception: " + e);
        }
        
    }
    
    /**
    Runs the server. Creates a new ServerSocket set to listen to a given 
    port. Runs an infinite loop to listen to the port, when a client is 
    found, a new ServerThread is created to handle that client, and continues
    to listen for another client. Handles all exceptions and prints the error
    to the console.
    */
    public void run()
    {
        try
        {
            ServerSocket serv_sock = new ServerSocket(PORT);
           
            FileOutputStream fs = new FileOutputStream("prog2.log", true);
            PrintWriter pw = new PrintWriter(fs, true);
            
            while (true)
            {
                Socket socket = serv_sock.accept();
                ServerThread serv = new ServerThread(socket, pw);
                serv.start();           
            }
        }
        catch (FileNotFoundException e)
        {
            System.out.println("File Exception: " + e);
        }
        catch (Exception e)
        {
            System.out.println("Exception :" + e);
        }
    }       
}
