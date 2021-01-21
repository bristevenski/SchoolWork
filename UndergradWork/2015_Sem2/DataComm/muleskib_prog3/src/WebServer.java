import java.io.*;
import java.net.*;

/**
Represents a web server. Runs a server socket and listens for connections
on the specified port.
@author Brianna Muleski
*/
public class WebServer 
{
    final int PORT = 5764;
   
    /**
    Creates a new WebServer and runs the WebServer. Catches any exceptions from
    the command line arguments and prints the error to the console.
    @param argv command line arguments
    */
    public static void main(String argv[])    
    {
        try
        {
            WebServer serv = new WebServer();
            serv.run();
        }
        catch (Exception e)
        {
            System.out.println("Exception: " + e);
        }
        
    } //end of main()
    
    /**
    Creates a server socket object that listens on the specified port. Handles
    the connection with an HTTPRequest thread object. Catches all exceptions
    and outputs an error message.
    */
    public void run()
    {
        try
        {
            ServerSocket serv_sock = new ServerSocket(PORT);
            System.out.println("Server is running...");
            
            while (true)
            {
                Socket client = serv_sock.accept();
                String ip = client.getInetAddress().toString();
                int port = client.getPort();
                
                System.out.println("Got a connection from " 
                                    + ip + " Port: " + port);
                HTTPRequest HTTP_thread = new HTTPRequest(client);
                HTTP_thread.start();
            }
         
        }
        catch (IOException e)
        {
            System.out.println("I/O Exception :" + e + " caught in WebServer.");
        }
        catch (Exception e)
        {
            System.out.println("Exception : " + e + " caught in WebServer");
        }
    } //end of run()
}
