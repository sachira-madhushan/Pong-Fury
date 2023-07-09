using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System;
public class Player : MonoBehaviour
{
    private PhotonView photonView;
    private string command = "";
    Thread receiveThread;
    UdpClient client;
    int port;
    float com;
    /*public GameObject player;*/
    String move;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        port = 22222;
        InitUDP();
    }
    private void InitUDP()
    {
        print("UDP Initialized");

        receiveThread = new Thread(new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();

    }
    private void ReceiveData()
    {
        client = new UdpClient(port);
        while (true)
        {
            try
            {
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
                byte[] data = client.Receive(ref anyIP);

                command = Encoding.UTF8.GetString(data);
                command = Encoding.UTF8.GetString(data);
                com = float.Parse(command) % 3.2f; 
            }
            catch (Exception e)
            {
                print(e.ToString());
            }
        }
    }
    void FixedUpdate()
    {
        if (photonView.IsMine)
        {
            this.transform.position = new Vector3( this.gameObject.transform.position.x,com * Time.timeScale, 0);
        }
            
    }
    
}
