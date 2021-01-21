import java.io.*;
import java.util.*;
import java.net.*;

/**
HTTP handles the GET request from the client. The request is parsed,
evaluated, and responded to with the correct status. If the requested
file is found, the file is written to the output stream. The status of these
actions is written to the server's system output.
@author Brianna Muleski
*/
class HTTP 
{
    final String CRLF = "\r\n";
    final String VERSION = "HTTP/1.0 ";
    final String HEADER = "Content-type: ";
    final String OK = "200 OK";
    final String NOT_FOUND = "404 Not Found";
    final int CHUNK_SIZE = 1024;
    final int PARSE = 2;
    
    DataOutputStream out;
    FileInputStream in;
    BufferedReader br;
    String file;
    Socket client;
    
    /**
    Constructor. Sets the DataOutputStream object to the given stream.
    @param output - the output stream used for server/client interaction
    */
    public HTTP(Socket sock) throws IOException
    {
        client = sock;
        out = new DataOutputStream(client.getOutputStream());
        br = new BufferedReader(
             new InputStreamReader(client.getInputStream()));
    }
   
    /**
    Responds to the given requests.
    @param request - the request message from the client
    @throws IOException - I/O exception from calling EntityBody()
    */
    public void Respond() throws IOException
    {
       String request = GetRequest();
        if(request == null)
        {
            System.out.println("Empty request");
            return;
        }
        boolean file_exists = true;
        try 
        {
            boolean correct_method = ParseRequest(request);
            if(!correct_method)
            {
                System.out.println("Incorrect method called");
                return;
            }
            else
            {
                in = new FileInputStream(file);
            }
        } 
        catch (FileNotFoundException ex) 
        {
            file_exists = false;
        }
        catch (Exception ex)
        {
            System.out.println("Exception: " + ex + " caught in HTTP.");
        }
        ComposeResponse(file_exists, file);
        EntityBody(file_exists);
    } //end of Respond()

    /**
    Parses the request string to extract the file requested. Checks for a 
    valid GET request.
    @param request - the request from the client
    @return true if GET is the request method, false otherwise
    */
    private boolean ParseRequest(String request) 
    {
        if(request != null)
        {
            StringTokenizer st = new StringTokenizer(request);
            String token = st.nextToken();

            if(token.equals("GET"))
            {
                token = st.nextToken();
                file = "." + token;
                return true;
            }
        }
        return false;
    } //end of ParseResponse()

    /**
    Composes the response to the client's request. If the file exists, an
    OK status code and phrase is added to the version and a header is added to
    the end of the response. If the file does not exist, a not found status
    code and phrase is added to the version.
    @param file_exists - boolean; represents whether the file exists or not
    @param req_file - the file requested
    @return 
    */
    private void ComposeResponse(boolean file_exists, String req_file) 
    {
        try
        {
            String response = VERSION;
            if(file_exists)
            {
                response += OK + CRLF;
            }
            else
            {
                response += NOT_FOUND + CRLF;
            }
            String value = ContentType(req_file);
            response += HEADER + value + CRLF;
            out.writeBytes(response);
            out.flush();
        }
        catch (IOException ex)
        {
            System.out.println("Socket Execption: " + ex);
        }

    } //end of ComposeResponse()
    
    /**
    Finds the file type based on the extension. Composes the MIME type
    for the response.
    @param fileName - the file given
    @return the MIME type of the file given
    */
    private String ContentType(String fileName)
    {
        String type = "application/octet-stream";
      
        if(fileName.endsWith(".htm") || fileName.endsWith(".html"))
        {
            type = "text/html" + CRLF;
        }
        if(fileName.endsWith(".gif"))
        {
            type = "image/gif" + CRLF;
        }
        if(fileName.endsWith(".bmp"))
        {
            type = "image/bmp" + CRLF;
        }
        if(fileName.endsWith(".jpeg") || fileName.endsWith(".jpg"))
        {
            type = "image/jpeg" + CRLF;
        }
        if(fileName.endsWith(".png"))
        {
            type = "image/png" + CRLF;
        }
      
        return type;
    } //end of ContentType()
   
    /**
    Composes the entity body for the response. If the file exists, the file
    is read in 1024-byte chunks, and written to the clients output stream. If
    the file does not exists, a "not found" message is used.
    @param file_exists - boolean; represents whether the file exists or not
    @throws IOException - exception thrown from input/output streams
    */
    private void EntityBody(boolean file_exists) throws IOException
    {
        if(file_exists)
        {
            byte[] buffer = new byte[CHUNK_SIZE];
            int buff_size = in.read(buffer);
            while(buff_size != -1)
            {
                out.write(buffer, 0, buff_size);
                out.flush();
                buff_size = in.read(buffer);
            }
            String parsed_file = file.substring(PARSE);
            System.out.println("File sent: " + parsed_file);
            
            in.close();
        }
        else
        {
            String body = "<HTML>" + "<HEAD><TITLE>Not Found</TITLE></HEAD>"                  
                    + "<BODY>Not Found</BODY></HTML>";
            out.writeBytes(body);
            System.out.println("File requested not found.");
        }
    } //end of EntityBody()

   /**
   Gets the request from the client. Handles an IO Exception and prints
   the exception to the system output.
   @return the request from the client.
   */
   private String GetRequest()
   {
      String req = null;
      try
      {
         req = br.readLine();
         System.out.println("Request: " + req);
      }
      catch (IOException ex)
      {
         System.out.println("Socket Exception: " + ex + " caught in HTTP.");
      }
      return req;
   } //end of GetRequest()
} //end of HTTP class
