import java.util.*;
import java.net.*;
import java.io.*;

/**
PingServer represents a Ping server utilizing UDP protocol. Listens for a
packet sent from a client and responds to the client.
@author Brianna Muleski
*/
public class PingServer 
{
    private final int AVERAGE_DELAY = 100;
    private final int DOUBLE = 2;
    private final double LOSS_RATE = 0.3;
    private final int PORT = 5750;
    private final int PACKET_SIZE = 512;
   
    private DatagramSocket udp_socket;
    private DatagramPacket in_packet;
   
    /**
    Creates a PingServer object and runs the PingServer.
    Catches all exceptions and prints the error message.
    @param args command line arguments
    */
    public static void main(String args[])
    {
        try
        {
            PingServer serv = new PingServer();
            serv.run();
        }
        catch (Exception e)
        {
            System.out.println("Exception: " + e);
        }

    }

    /**
    Runs the PingServer. Listens for a packet on the specified port. When
    a message is, the message is "echoed" back to the client. Simulates
    packet loss and transmission delay. 
    Catches an IOException thrown by ReceiveUDPPacket and SendUDPPacket.
    Catches a SocketException if an error occurs while creating the 
    DatagramSocket object.
    */
    private void run() 
    {
        try
        {
            Random rnd = new Random(new Date().getTime());
            udp_socket = new DatagramSocket(PORT);
            System.out.println("Ping Server running...");
            while (true)
            {
                byte[] buff = new byte[PACKET_SIZE];
                in_packet = new DatagramPacket(buff, PACKET_SIZE);                                
                buff = ReceiveUDPPacket(buff);
                double loss = rnd.nextDouble();
                if(loss > LOSS_RATE)
                {
                    String message = new String(buff);
                    StringTokenizer st = new StringTokenizer(message);
                    st.nextToken();
                    st.nextToken();
                    String payload = st.nextToken() + " " + st.nextToken() 
                                     + " " + st.nextToken();
                    SendUDPPacket(payload);
                }
                else
                {
                    System.out.println("Packet loss. Reply not sent.");
                }
            }
        }
        catch (SocketException e)
        {
            System.out.println("IO Exception :" + e.getMessage());
        }
        catch (IOException e)
        {
            System.out.println("IO Exception :" + e.getMessage());
        }
    }
    
    /**
    Listens for a UDP packet to be sent and receives it.
    @return the UDP packet in a byte array
    @throws IOException if an error occurs while receiving the UDP packet
    */
    private byte[] ReceiveUDPPacket(byte[] buff) throws IOException
    {
        System.out.println("Waiting for UDP packet...");
        udp_socket.receive(in_packet);
        InetAddress client_ip = in_packet.getAddress();
        String message = new String(buff);
        StringTokenizer st = new StringTokenizer(message);
        st.nextToken();
        st.nextToken();
        String ping = st.nextToken();
        String seq = st.nextToken();
        String timestamp = st.nextToken();
        System.out.println("Packet recieved from: " + client_ip + " " + ping +
                            " " + seq + " " + timestamp);                    
        return buff;
    }

    /**
    Sends a UDP packet stored in the given byte array.
    @param buff the byte array representation of the UDP packet
    @throws IOException if an error occurs while sending the UDP packet
    */
    private void SendUDPPacket(String payload) throws IOException
    {
       try 
       {
           Random rnd = new Random(new Date().getTime());
           int client_port = in_packet.getPort();
           InetAddress client_ip = in_packet.getAddress();
           int trans_delay = (int) rnd.nextDouble() * DOUBLE *
                   AVERAGE_DELAY;
           Thread.sleep(trans_delay);
           byte[] pay_buff = payload.getBytes();
           DatagramPacket out_packet = new DatagramPacket
                        (pay_buff, pay_buff.length, client_ip, client_port);
           udp_socket.send(out_packet);
           System.out.println("Reply sent.");
       } 
       catch (InterruptedException e) 
       {
           System.out.println("Thread exception: " + e.getMessage());
       }
    }
}
