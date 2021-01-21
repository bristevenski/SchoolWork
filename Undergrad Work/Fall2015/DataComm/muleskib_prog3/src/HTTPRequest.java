import java.net.*;
import java.io.*;

/**
HTTPRequest handles a client request. The class creates input and output
streams, reads the clients request, and sends a response. After the response
is sent, the input, output, and socket are closed.
@author Brianna Muleski
*/
class HTTPRequest extends Thread
{
    private final Socket socket;
    private BufferedReader in;
    private DataOutputStream out;
   
    /**
    Constructor. Sets socket to the given socket.
    @param clientSock - the client socket
    */
    public HTTPRequest(Socket clientSock)
    {
        socket = clientSock;
    } //end of HTTPRequest()
   
    @Override
    /**
    Runs the request thread. Creates input and output streams, creates and new
    HTTP object, and uses that object to respond to the client. Closes the
    input, output, and socket when the response is completed. Catches an
    IO Exception and prints the message to the system output.
    */
    public void run()
    {
        try
        {
            in = new BufferedReader(new InputStreamReader
                                    (socket.getInputStream()));
            out = new DataOutputStream(socket.getOutputStream());
            HTTP http = new HTTP(socket);
            http.Respond();

            in.close();
            out.close();
            socket.close();
        }
        catch (IOException ex)
        {
            System.out.println("IO Exception: " + ex 
                                + " caught in HTTPRequest.");
        }
    } //end of run()
}
