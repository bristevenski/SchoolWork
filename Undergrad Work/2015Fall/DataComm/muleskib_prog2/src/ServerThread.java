import java.net.*;
import java.io.*;
import java.util.*;

/**
Runs a thread of a server, encrypts the message received from a client,
and sends the encrypted message back to the client. Logs all interaction
between the client and the server in a logfile. Handles all exceptions and
prints an appropriate message.
@author Brianna Muleski
*/
class ServerThread extends Thread
{
    Socket socket;
    PrintWriter out;
    PrintWriter log;
    BufferedReader in;
    
    /**
    Constructor: sets socket to the Socket given and log to the PrintWriter
    given.
    @param clientSock the socket being used for this thread
    @param logfile the file to be written in
    */
    public ServerThread(Socket clientSock, PrintWriter logfile)
    {
        socket = clientSock;
        log = logfile;
    }
    
    /**
    Runs the ServerThread. Initializes the input and output streams, logs
    all interaction between the client and the server, reads the messages
    received from the client and sends the message encrypted to the client.
    Handles all exceptions and logs the error in the file. Closes the
    socket when the client quits.
    */
    @Override
    public void run()
    {
        try
        {
            int port = socket.getPort();
            PolyAlphabet pa = new PolyAlphabet();
            Initialize();
            String message = in.readLine();
            log.println("Client " + port + " sent: " + message);
       
            while(!message.equalsIgnoreCase("quit"))
            {
                String out_msg = pa.Encrypt(message);
                log.println("Message encrypted: " + out_msg);
                out.println(out_msg);
                message = in.readLine();
                log.println("Client " + port + " sent: " + message);
            }
            
            CloseSocket();
        }
        catch (IOException e)
        {
            log.println("Input/Output Exception: " + e);
        }
        catch (Exception e)
        {
            log.println("Exception: " + e);
        }
    }

    /**
    Initializes the input and output streams for the client/server
    communication. Handles all exceptions and logs the error.
    */
    private void Initialize() 
    {
        try
        {
            out = new PrintWriter(socket.getOutputStream(), true);
            in = new BufferedReader(new InputStreamReader
                                (socket.getInputStream()));
            Date dt = new Date();
            log.println("Got connection: " + dt.toString() + " "
                        + socket.getInetAddress().toString() + " Port: " 
                        + socket.getPort());
        }
        catch (IOException e)
        {
            log.println("Input/Output Exception: " + e);
        }
        catch (Exception e)
        {
            log.println("Exception: " + e);
        }
    }

    /**
    Sends closing messages and closes the socket. Handles all exceptions
    and logs the error.
    */
    private void CloseSocket() 
    {
        try
        {
            out.println("Goodbye!");
            log.println("Connection closed. Port: " 
                        + socket.getPort());
            socket.close();  
        }
        catch (Exception e)
        {
            log.println("Exception: " + e);
        }
    }
    
    
}
