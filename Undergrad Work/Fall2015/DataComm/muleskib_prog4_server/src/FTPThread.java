import java.io.*;
import java.util.*;
import java.net.*;

/**
Handles a single client connection. Uses a control connection
to establish the connection, then opens a data connection each time
a file is sent or received. Prints status of connection and file transfer.
@author Brianna Muleski
*/
class FTPThread extends Thread
{
    final int CHUNK_SIZE = 1024;
    static int data_port = 5722;
    private final String CRLF = "\r\n";
    
    // Control connection objects
    DataOutputStream out;
    BufferedReader in;
    Socket client;
    
    // Data connection objects
    DataOutputStream d_out;
    DataInputStream d_in;
    ServerSocket d_socket;
    Socket d_client;
    
    File[] files;
    
    /**
    Constructor. Creates an FTPThread object and initializes the input
    and output for the given client socket. 
    @param sock the client socket
    @throws IOException if an error occurs when creating the I/O streams.
    */
    public FTPThread(Socket sock) throws IOException
    {
        client = sock;
        out = new DataOutputStream(client.getOutputStream());
        in = new BufferedReader(
             new InputStreamReader(client.getInputStream()));
    } //end of FTPThread()
    
    @Override
    /**
    Runs the request thread. Attempts to respond to the client. Catches an
    IO Exception thrown by Respond().
    */
    public void run()
    {
        try
        {
            Respond();
        }
        catch (IOException ex)
        {
            System.out.println("IO Exception: " + ex.getMessage());
        }
    } //end of run()
    
    /**
    Responds to the client. Stays alive until the control connection is closed.
    @throws IOException if an error occurs while reading the control input
            stream.
    */
    public void Respond() throws IOException
    {
        boolean connected = true;
        ListFiles();
        while(connected)
        {
            String request = in.readLine();
            connected = ProcessRequest(request);
            if(connected)
            {
                ListFiles();
            }
        }      
    } //end of Respond()
    
    /**
    Opens a data connection. Uses a port dedicated to the data connection and
    increments that port number for the next data connection needed. Sends the 
    client the data port to connect to via the control connection and listens
    for the client to respond. Prints the data connection information when the
    connection has been successfully established. Catches an IOException if an
    error occurs when establishing the new connection or outputting through 
    the control output stream. 
    @return true if connected successfully, false otherwise
     */
    private boolean OpenDataConnection()
    {
        boolean result = true;
        try 
        {
            d_socket = new ServerSocket(data_port);
            String d_port = Integer.toString(data_port);
            out.writeBytes(d_port + CRLF);
            data_port++;
            d_client = d_socket.accept();
            d_in = new DataInputStream(d_client.getInputStream());
            d_out = new DataOutputStream(d_client.getOutputStream());
            
            System.out.println("Data Connection open for:");
            System.out.println("Local port: " + d_client.getLocalPort());
            System.out.println("Remote port: " + d_client.getPort());
        } 
        catch (IOException ex) 
        {
            System.out.println("IO Exception: " + ex.getMessage());
            result = false;
        }
        return result;
    } //end of OpenDataConnection()
    
    /**
    Closes the data connection. Prints the information for the connection that
    was closed. Catches an IOExcpetion if an error occurs when attempting to
    close the data connection and its I/O stream.
    */
    private void CloseDataConnection()
    {
        try 
        {
            if(d_socket != null && !d_socket.isClosed())
            {
                d_in.close();
                d_out.close();
                d_socket.close();
                d_client.close();
            }
            System.out.println("Data Connection closed for:");
            System.out.println("Local port: " + d_client.getLocalPort());
            System.out.println("Remote port: " + d_client.getPort());
        } 
        catch (IOException ex) 
        {
            System.out.println("IOException: " + ex.getMessage());
        }
    } //end of CloseDataConnection()
    
    /**
    Sends the list of the server files to the client via the control connection.
    Catches an IOException if an error occurs when attempting to send the file
    list.
    */
    private void ListFiles()
    {
        try 
        {
            File dir = new File("Files");
            files = dir.listFiles();
            String list_files = "";
            for(int i = 0; i < files.length; i++)
            {
                if(files[i].isFile())
                {
                    list_files += files[i].getName() + " ";
                }
            }
            out.writeBytes(list_files + CRLF);
        } 
        catch (IOException ex) 
        {
            System.out.println("IO Exception: " + ex.getMessage());
        }
    } //end of ListFiles()
    
    /**
    Sends the requested file via the data connection, if it exists. Opens a
    data connection, and if the connection is opened successfully then sends 
    the file in 1024-byte chunks. Closes the connection. Prints the status of
    the file transfer.
    @param filename the requested file
    @throws FileNotFoundException if the file requested is not found.
    @throws IOException if an error occurs when reading from the file or 
            writing to the output stream.
    */
    private void SendFile(String filename) throws FileNotFoundException, 
                                                  IOException
    {
        boolean no_error = OpenDataConnection();
        if(no_error)
        {
            for(int i = 0; i < files.length; i++)
            {
                if(files[i].isFile())
                {
                    if(files[i].getName().equalsIgnoreCase(filename))
                    {
                        String path = "Files\\" + filename;
                        File file = new File(path);
                        FileInputStream f_in = new FileInputStream(file);
                        System.out.println("Sending the file...");
                        byte[] buffer = new byte[CHUNK_SIZE];
                        int buff_size = f_in.read(buffer);
                        while(buff_size != -1)
                        {
                            d_out.write(buffer, 0, buff_size);
                            buff_size = f_in.read(buffer);
                        }
                        f_in.close();
                        System.out.println("File: " + filename);
                        System.out.println(file.length() + " bytes sent");
                        CloseDataConnection();
                    } //end of if(files[i].getName().equalsIgnoreCase(filename))
                } //end of if(files[i].isFile())
            } //end of for(int i = 0; i < files.length; i++)
        } //end of if(no_error)  
    } //end of SendFile()
    
    /**
    Downloads the file sent by the client. Opens a data connection, and if the
    connection is opened successfully then downloads the file in 1024-byte 
    chunks. Closes the connection. Prints the status of the file transfer. 
    @param filename the sent file
    @throws FileNotFoundException if the file sent is not found.
    @throws IOException if an error occurs when writing to the file or 
            reading from the input stream.
    */
    private void GetFile(String filename) throws FileNotFoundException, 
                                                 IOException
    {
        boolean no_error = OpenDataConnection();
        if(no_error)
        {
            System.out.println("Receiving the file...");
            String path = "Files\\" + filename;
            File file = new File(path);
            FileOutputStream f_out = new FileOutputStream(file);
            byte[] buffer = new byte[CHUNK_SIZE];
            int buff_size = d_in.read(buffer);
            while(buff_size != -1)
            {
                f_out.write(buffer, 0, buff_size);
                buff_size = d_in.read(buffer);
            }  
            f_out.close();
            System.out.println("File: " + filename);
            System.out.println("Size: " + file.length() + "bytes");
            CloseDataConnection();
        }
    } //end of GetFile()

    /**
    Processes the request sent by the client via the control connection.
    @param request the sent request
    @return true if the control connection is still open, false otherwise.
    */
    private boolean ProcessRequest(String request) 
    {
        boolean result = true;
        StringTokenizer st = new StringTokenizer(request);
        String req = st.nextToken();
        
        if(req == null)
        {
            System.out.println("Empty request");
        }
        else if(req.equalsIgnoreCase("DISCONNECT"))
        {
            System.out.println("Control connection closed for:");
            System.out.println("Local port: " + client.getLocalPort());
            System.out.println("Remote port: " + client.getPort());
            result = false;
        }
        else
        {
            String file = st.nextToken();
            HandleFileTransfer(file, req);
        }
   
        return result;
    } //end of ProcessRequest()
    
    /**
    Handles the file transfer. If the request is GET, then sends the file
    requested. If the request is PUT, then downloads the file sent. Catches
    an IOException and FileNotFoundException thrown by SendFile() and GetFile().
    @param file the file to send or download
    @param req the sent request
    */
    private void HandleFileTransfer(String file, String req)
    {
        try
        {
            if(req.equalsIgnoreCase("GET"))
            {
                SendFile(file);
            }
            else if (req.equalsIgnoreCase("PUT"))
            {
                GetFile(file);
            }
            else
            {
                System.out.println("Incorrect method called");
            }
        }
        catch(FileNotFoundException ex)
        {
            System.out.println("File requested not found.");
        }
        catch(IOException ex)
        {
            System.out.println("IO Exception: " + ex.getMessage());
        }
    } //end of HandleFileTransfer()
} //end of FTPThread class
