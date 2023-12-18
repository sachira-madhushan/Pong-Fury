using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
public class CreateAndJoin : MonoBehaviourPunCallbacks
{
    public TMP_InputField RoomCode, PlayerName;
    void Start()
    {
        
    }
    
    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(RoomCode.text);
        PlayerPrefs.SetString("PlayerName", PlayerName.text);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(RoomCode.text);
        PlayerPrefs.SetString("PlayerName", PlayerName.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }
}
