using System;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Multiplayer
{
    public class TCP
    {
        private Client _client;
        public Socket TcpClient;
        private int dataBufferSize;
        private byte[] receiveBuffer;


        public TCP(Client client)
        {
            _client = client;
            receiveBuffer = client.Buffer;
            dataBufferSize = client.dataBufferSize;
        }

        /// <summary>Attempts to connect to the server via TCP.</summary>
        public void Connect()
        {
            TcpClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            receiveBuffer = new byte[dataBufferSize];
            IAsyncResult result = TcpClient.BeginConnect(_client.ip, _client.port, ConnectCallback, TcpClient);
            bool succes = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(1));

            if (!succes)
            {
                Debug.Log("Niet kunnen verbinden met de server staat hij aan?");
            }
            else
            {
                Debug.Log("Verbonden met IP" + _client.ip + " and port: " + _client.port);
            }
        }

        private void ConnectCallback(IAsyncResult result)
        {
            Socket client = (Socket) result.AsyncState;
            
            client.BeginReceive(receiveBuffer, 0, receiveBuffer.Length, SocketFlags.None, ReceiveCallback, null);
        }

        private void ReceiveCallback(IAsyncResult result)
        {
            byte[] buffer = (byte[]) result.AsyncState;
            int count = TcpClient.EndReceive(result);

            if (count > 0)
            {
                Debug.Log("Gwn bericht :)");
                string text = Encoding.ASCII.GetString(buffer);
                Debug.Log(text);
            }
            else
            {
                Debug.Log("Disconnected");
            }

            buffer = new byte[1024];
            TcpClient.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReceiveCallback, buffer);
        }
        
        public void SendData(Socket target, string msg)
        {  
            byte[] byteData = Encoding.ASCII.GetBytes(msg);
            target.BeginSend(byteData, 0, byteData.Length, 0, SendCallback, target);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket handler = (Socket) ar.AsyncState;

                // Complete sending the data to the remote device.  
                int bytesSent = handler.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to client.", bytesSent);

                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }


        private void Disconnect()
        {
            TcpClient.Close();
            receiveBuffer = null;
            TcpClient = null;
        }
    }
}