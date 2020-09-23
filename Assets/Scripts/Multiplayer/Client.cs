using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using Assets.Scripts.Multiplayer;
using UnityEngine;

public class Client : MonoBehaviour
{
    public int dataBufferSize = 4096;
    public byte[] Buffer = new byte[256];

    public string ip = "127.0.0.1";
    public int port = 32000;
    public TCP tcp;

    private bool isConnected = false;

    private void Awake()
    {
        tcp = new TCP(this);
        ConnectToServer();
    }

    private void OnApplicationQuit()
    {
        Disconnect();
    }
    
    public void ConnectToServer()
    {
        tcp.Connect(); // Connect tcp
        isConnected = true;
    }
    
    public void Disconnect()
    {
        if (isConnected)
        {
            isConnected = false;
            tcp.TcpClient?.Close();

            Debug.Log("Disconnected from server.");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            tcp.SendData(tcp.TcpClient, "Dit is een random bericht wat ik naar de server wil sturen.");
            print("Data verzonden");
        }
    }
}