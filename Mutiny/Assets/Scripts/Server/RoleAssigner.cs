using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RoleAssigner : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AssignRoles()
    {
        int range = PhotonNetwork.PlayerList.Length;
        int result = Random.Range(1, range);

        Photon.Realtime.Player selectedPlayer = PhotonNetwork.PlayerList[result];

        //selectedPlayer.photonView;

        selectedPlayer.GameObject.Get
    }
}
