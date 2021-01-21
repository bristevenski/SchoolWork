import java.net.*;
import java.util.Date;

/**
Creates a Ping message that contains the destination address and port number, 
and in addition the payload for an incoming message 
@author Sydney Freisinger
*/
public class PingMessage 
{    
    private int portNum;
    private InetAddress IPAddress;
    private String payload;

    /**
    Constructor. Creates a ping message given the address, port, and payload.
    @param addr the destination IP address
    @param port the destination port number
    @param in_payload the payload for the message
    */
    public PingMessage(InetAddress addr, int port, String in_payload)
    {
        IPAddress = addr;
        portNum = port;
        payload = in_payload;
        Date dt = new Date();
        payload += " " + dt.getTime();
    }

    /**
    Gets the IP address for the message.
    @return destination IP address
    */
    public InetAddress getIP()
    {
       return IPAddress;
    }

    /**
    Gets the port number for the message.
    @return destination port number
    */
    public int getPort()
    {
       return portNum;
    }

    /**
    Gets the payload for the message.
    @return payload
    */
    public String getPayload()
    {
        return payload;
    }
}
