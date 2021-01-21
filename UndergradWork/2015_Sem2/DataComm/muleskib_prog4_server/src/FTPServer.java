import java.io.*;
import java.net.*;

/**
Represents a server. Runs a server socket and listens for connections
on the specified port.
@author Brianna Muleski
*/
public class FTPServer 
{
    final int PORT = 5721;
   
    /**
    Creates a new FTPServer and runs the server. Catches any exceptions
    from the command line arguments and prints the error to the console.
    @param argv command line arguments
    */
    public static void main(String argv[])    
    {
        try
        {
            FTPServer serv = new FTPServer();
            serv.run();
        }
        catch (Exception e)
        {
            System.out.println("Exception: " + e);
        }
        
    } //end of main()
    
    /**
    Creates a server socket object that listens on the specified port. Handles
    the connection with an FTPServer thread object. Catches all exceptions
    and outputs an error message.
    */
    public void run()
    {
        try
        {
            ServerSocket serv_sock = new ServerSocket(PORT);
            System.out.println("FTP Server is running...");
            
            while (true)
            {
                Socket client = serv_sock.accept();
                String ip = client.getInetAddress().toString();
                int port = client.getPort();
                
                System.out.println("Got a connection from: " 
                                    + ip + "on local port: " 
                                    + client.getLocalPort() + " remote port: " 
                                    + port);
                FTPThread server_thread = new FTPThread(client);
                server_thread.start();
            }
         
        }
        catch (IOException e)
        {
            System.out.println("IO Exception :" + e.getMessage());
        }
        catch (Exception e)
        {
            System.out.println("Exception : " + e.getMessage());
        }
    } //end of run()
} //end of FTPServer class