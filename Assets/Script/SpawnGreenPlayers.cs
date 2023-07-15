using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class SpawnGreenPlayers : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        PhotonNetwork.Instantiate(player.name, new Vector2(2.75f, -0.15f), Quaternion.identity);
    }

}
