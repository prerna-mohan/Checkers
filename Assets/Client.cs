using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.IO;
using System;
using UnityEngine;

public class Client : MonoBehaviour
{
    private bool socketReady;
    private TcpClient socket;
    private NetworkStream stream;
    private StreamWriter writer;
    private StreamReader reader;
    private void Update(){
        if(socketReady){
            if(stream.DataAvailable){
                string data = reader.ReadLine();
                if(data!=null)
                    OnIncomingData(data);
            }
        }
    }
    public bool ConnectToServer(string host, int port){
        if(socketReady)
            return false;
        try
        {
            socket = new TcpClient(host, port);
            stream = socket.GetStream();
            writer = new StreamWriter(stream);
            reader = new StreamReader(stream);
            socketReady = true;
        }
        catch (Exception e)
        {
            Debug.Log("socket error"+e.Message);
        }  
        return socketReady;  
    }   
    //read messages from the server
    private void OnIncomingData(string data){

    }
    public void Send(string data){
        if(!socketReady)
            return;
        writer.WriteLine(data);
        writer.Flush();    
    }
    private void OnApplicationQuit(){
        CloseSocket();
    }
    private void OnDisable(){
        CloseSocket();
    }
    public void CloseSocket(){
        if(!socketReady)
            return;
        writer.Close();
        reader.Close();
        socket.Close();
        socketReady = false;    
    }
}

public class GmaeClient{
    public string Name;
    public bool isHost;
}
