import java.io.*;
import java.net.*;

/**
Represents a UDP pinger. Sends PingMessages and encapsulates them, and 
receives PingMessages and breaks down the encapsulation before creating the
ping.
@author Sydney Freisinger
*/
public class UDPPinger 
{
    private final int PACKET_SIZE = 512;
    protected DatagramSocket udp_socket;
    
    /**
    Sends the ping message to the server. Encapsulates the PingMessage in a
    UDP packet and sends the packet via the established socket.
    @param ping the message to send
    @throws IOException if an error occurs when sending the packet.
    */
    public void sendPing(PingMessage ping) throws IOException
    {
        byte[] ip = (ping.getIP().toString() + " ").getBytes();
        byte[] prt = (Integer.toString(ping.getPort()) + " ").getBytes();
        byte[] payload = ping.getPayload().getBytes();
        byte[] buff = new byte[ip.length + prt.length + payload.length];
        System.arraycopy(ip, 0, buff, 0, ip.length);
        System.arraycopy(prt, 0, buff, ip.length, prt.length);
        System.arraycopy(payload, 0, buff, ip.length + prt.length, 
						 payload.length);
        InetAddress add = ping.getIP();
        int port = ping.getPort();
        DatagramPacket out_packet = new DatagramPacket(buff, buff.length, add, 
													   port);
        udp_socket.send(out_packet);
    }

    /**
    Receives a message from the server through the given socket. Breaks down
    the packet received and constructs a Ping message using the data.
    @return ping - the PingMessage created given the UDP packet
    @throws IOException if an error occurs when receiving the packet.
    @throws SocketTimeoutException if a timeout occurs when waiting for the packet.
    */
    public PingMessage receivePing() throws IOException, SocketTimeoutException
    {
        PingMessage ping;
        byte[] buff = new byte[PACKET_SIZE];
        DatagramPacket in_packet = new DatagramPacket(buff, PACKET_SIZE);
        udp_socket.receive(in_packet);
        String payload = new String(in_packet.getData());
        InetAddress add = in_packet.getAddress();
        int port = in_packet.getPort();
        ping = new PingMessage(add, port, payload);
        return ping;
    }
}
