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
    String move;
    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        port = 5065;
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
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Parse("0.0.0.0"), port);
                byte[] data = client.Receive(ref anyIP);

                command = Encoding.UTF8.GetString(data);
                if (command[0] == '5' || command[0] == '4' || command[0] == '2' || command[0] == '1')
                {
                    move = "Right";

                    print("command :" + command[0]);
                }
                else if (command[0] == '3')
                {
                    move = "Left";

                    print("command :" + command[0]);
                }
                else if (command[0] == '0')
                {
                    move = "";
                }
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
            if (move == "Right")
            {
                this.transform.position = new Vector3(this.transform.position.x,(this.transform.position.y + 0.1f) * Time.timeScale, 0);
            }
            else if (move == "Left")
            {
                this.transform.position = new Vector3(this.transform.position.x, (this.transform.position.y - 0.1f) * Time.timeScale, 0);
            }
        }
            
    }
    
}
