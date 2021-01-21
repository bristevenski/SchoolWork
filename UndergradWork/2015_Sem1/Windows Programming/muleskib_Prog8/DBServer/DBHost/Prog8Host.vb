Imports UWPCS3340
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp
Imports System.Net

Public Class Prog8Host
    Private Shared IPAddress As System.Net.IPAddress
    Private Shared IPHEntry As System.Net.IPHostEntry

    Public Shared Sub Main()
        IPHEntry = System.Net.Dns.GetHostEntry(Environment.MachineName)
        For Each LocalIP As System.Net.IPAddress In IPHEntry.AddressList
            If LocalIP.AddressFamily = Sockets.AddressFamily.InterNetwork Then
                IPAddress = LocalIP
                Exit For
            End If
        Next
        ' Registers channel
        ChannelServices.RegisterChannel(New TcpServerChannel(8081), False)
        Console.WriteLine("Server " & " at IP address " & IPAddress.ToString)
        Console.WriteLine()

        Dim Url As String = "Prog8"
        'Console.WriteLine("Registering: " & GetType(Customers).ToString)
        Console.WriteLine("URI: " & Url)
        'RemotingConfiguration.RegisterWellKnownServiceType( _
        'GetType(Customers), Url, WellKnownObjectMode.Singleton)
        'Console.WriteLine("Registered: " & GetType(Customers).ToString)

        ' Reads a line to terminate
        Console.ReadLine()
    End Sub

End Class
