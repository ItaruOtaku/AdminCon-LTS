using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
/* Project Amadeus - Windows Desktop Development SDK - HostLANConnectionInit.cs
* Feature: The Local Connection Module for Hosts.
* (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace Amadeus.Microsoft.Windows.CsharpDev.ToolBox.Net
{
    /// <summary>
    /// Hosts Between Local Area Network
    /// This module initialize data transfering connection for 2 hosts.
    /// </summary>
    public static class HostLANConnectionInit
    {
        /// <summary>
        /// Port 1.
        /// </summary>
        private const Int32 CONTROLLER_PORT = 9009;

        /// <summary>
        /// Port 2.
        /// </summary>
        private const Int32 ROBOT_PORT = 9019;

        /// <summary>
        /// A buffer area for data transfer. Byte[]
        /// </summary>
        private static Byte[] datapkg = new Byte[1024];

        /// <summary>
        /// Socket Object for host server.
        /// </summary>
        static Socket serverSocket;
        
        /// <summary>
        /// Get the IPv4 address of a host by its hostname.
        /// </summary>
        /// <param name="hostname"></param>
        /// <returns>IPAddress ipv4Address</returns>
        private static IPAddress getThatIPv4Address(String hostname)
        {
            try
            {
                IPAddress[] ipArray = Dns.GetHostAddresses(hostname);
                return ipArray[ipArray.Length-1];
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Get the IPv4 address of this computer.
        /// </summary>
        /// <returns>IPAddress ipv4Address</returns>
        private static IPAddress getThisIPv4Address()
        {
            return Dns.GetHostAddresses(Environment.MachineName)[Dns.GetHostAddresses(Environment.MachineName).Length-1];
        }

        /// <summary>
        /// Receive Byte data from another host.
        /// </summary>
        /// <param name="clientSocket"></param>
        private static void receive(Object clientSocket)
        {
            Socket thisSocket = (Socket)clientSocket;
            try
            {
                Int32 num = thisSocket.Receive(datapkg);
                Console.WriteLine(thisSocket.RemoteEndPoint.ToString(), UTF8Encoding.UTF8.GetString(datapkg, 0, num));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                thisSocket.Shutdown(SocketShutdown.Both);
                thisSocket.Close();
            }
        }

        /// <summary>
        /// Initialize the connection between 2 hosts.
        /// If it failed returns -1, otherwise returns 0;
        /// </summary>
        /// <param name="hostname"></param>
        /// <returns>Int32 statecode</returns>
        public static Int32 init(String hostname)
        {
            try
            {
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Bind(new IPEndPoint(getThatIPv4Address(hostname), ROBOT_PORT));
                serverSocket.Listen(10);
                return 0;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        /// <summary>
        /// Send a command to a host.
        /// </summary>
        /// <param name="command"></param>
        public static void sendCMD(String command)
        {
            Byte[] byteData = UTF8Encoding.UTF8.GetBytes(command);
            serverSocket.Send(byteData);
        }

        /// <summary>
        /// Get the response after the robot host executed the command.
        /// </summary>
        public static void getResponse()
        {
            Socket clientsocket = serverSocket.Accept();
            Thread receiveThread = new Thread(receive);
            receiveThread.Start(clientsocket);
        }
    }
}
