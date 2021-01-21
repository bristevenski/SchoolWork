import java.util.*;
import java.net.*;
import java.io.*;

/**
Represents a UDP client. Sends pings to a sever and waits for a response within
the specified timeout. Tracks RTT and outputs the results of each packet.
@author Brianna Muleski
*/
public class PingClient extends UDPPinger implements Runnable
{
    private final int CLIENT_PORT = 5751;
    private final int INIT_TIMEOUT = 1000;
    private final int FINAL_TIMEOUT = 5000;
    private final int NUM_PINGS = 10;
    private final String PNG = "PING ";
    
    private InetAddress server_add;
    private int server_port;
    
    private long[] rtt = new long[] 
    {
        INIT_TIMEOUT, INIT_TIMEOUT, INIT_TIMEOUT, INIT_TIMEOUT, 
        INIT_TIMEOUT, INIT_TIMEOUT, INIT_TIMEOUT,
        INIT_TIMEOUT, INIT_TIMEOUT, INIT_TIMEOUT
    };
    
    /**
    Creates a PingClient object and runs the client. Catches any exception and
    outputs the error message.
    @param args the command line arguments; args[0] - server's IP address,
                                            args[1] - server's port number
    */
    public static void main(String args[])
    {
        try
        {
            PingClient client = new PingClient(args[0], args[1]);
            client.run();
        }
        catch (Exception e)
        {
            System.out.println("Exception: " + e);
        }

    }

    /**
    Constructor. Initializes the server information.
    @param ip the server's IP address
    @param port the server's port number 
    */
    public PingClient(String ip, String port)
    {
        try 
        {
            server_add = InetAddress.getByName(ip);
            server_port = Integer.parseInt(port);
        } 
        catch (UnknownHostException e) 
        {
            System.out.println("UnknownHostException:" + e.getMessage());
        }
    }
    
    /**
    Runs the PingClient. catches a SocketException or IOException thrown by
    SendPings() and outputs the error message.
    */
    @Override
    public void run() 
    {
        try 
        {
            SendPings();
        }
        catch (SocketException e)
        {
            System.out.println("Socket Exception :" + e.getMessage());
        }
        catch (IOException e)
        {
            System.out.println("IO Exception :" + e.getMessage());
        }
    }
    
    /**
    Sends ping messages to the server via a UDP socket connection. Tracks
    round-trip time for each ping to be sent and received back. Catches a
    SocketTimeoutException if the socket times out when waiting for a packet.
    @throws SocketException if an error occurs when setting up the socket
    @throws IOException if an error occurs when sending or receiving packets
    */
    private void SendPings() throws SocketException, IOException
    {
        PingMessage message;
        Date dt = new Date();
        udp_socket = new DatagramSocket(CLIENT_PORT);
        udp_socket.setSoTimeout(INIT_TIMEOUT);
        int num_replies = 0;
        message = new PingMessage(server_add, server_port, PNG + "0");
        long send_time = dt.getTime();
        sendPing(message);
        for(int i = 1; i < NUM_PINGS; i++)
        {
            try
            {
                PingMessage ping = receivePing();
                rtt[i - 1] = dt.getTime() - send_time;
                num_replies++;
                ProcessPing(ping);
            }
            catch (SocketTimeoutException e)
            {
                System.out.println("receivePing..." + e);
            }
            finally
            {
                message = new PingMessage(server_add, server_port, PNG + i);
                send_time = dt.getTime();
                sendPing(message);
            }
        }
        if(num_replies < NUM_PINGS)
        {
            try
            {
                udp_socket.setSoTimeout(FINAL_TIMEOUT);
                PingMessage ping = receivePing();
                rtt[NUM_PINGS - 1] = dt.getTime() - send_time;
                num_replies++;
                ProcessPing(ping);
            }
            catch (SocketTimeoutException e)
            {
                System.out.println("receivePing..." + e);
            }
        }
        ComputeResults();
    }

    /**
    Processes the received ping message and prints the result to the output.
    @param ping the ping message received
    */
    private void ProcessPing(PingMessage ping)
    {
        String add = ping.getIP().toString();
        int port = ping.getPort();
        Date dt = new Date();
        System.out.println("Received packet from: " + add + " " + port + " " 
                            + dt.toString());
    }
    
    /**
    Computes the RTT values (minimum, maximum, and average) of the pings sent.
    Outputs the results.
    */
    private void ComputeResults() 
    {
        boolean result = true;
        long min = INIT_TIMEOUT;
        long max = 0;
        long sum = 0;
        for(int i = 0; i < rtt.length; i++)
        {
            if(rtt[i] == INIT_TIMEOUT)
            {
                result = false;
            }
            System.out.println(PNG + i + ": " + result + " RTT: " + rtt[i]);
            sum += rtt[i];
            if(rtt[i] < min)
            {
                min = rtt[i];
            }
            if(rtt[i] > max)
            {
                max = rtt[i];
            }
            result = true;
        }
        long ave = sum/NUM_PINGS;
        System.out.println("Minimum = " + min + "ms," + 
                           " Maximum = " + max + "ms," + 
                           " Average = " + ave + "ms.");
    }
}
