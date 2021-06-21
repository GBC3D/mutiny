using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Body : MonoBehaviourPunCallbacks 
{
    [SerializeField]
    private LayerMask playerMask;

    void OnTriggerExit(Collider other)
    {
        PhotonView photonView = other.GetComponent<PhotonView>();

        if (photonView != null && photonView.IsMine)
        {
            HidePlayers();
        }

    }

    void OnTriggerEnter(Collider other)
    {

        PhotonView photonView = other.GetComponent<PhotonView>();

        if (photonView != null && photonView.IsMine)
        {
            ShowPlayers();
        }

    }

    public void ShowPlayers()
    {
        Collider[] players = Physics.OverlapSphere(gameObject.transform.position, 150f);
        foreach (var player in players)
        {
            
            if(player.gameObject.GetComponent<PlayerUI>() != null)
            {
                
                player.gameObject.GetComponent<PlayerUI>().ShowReport();
            }
        }
    }

    //[PunRPC]
    public void HidePlayers()
    {
        Collider[] players = Physics.OverlapSphere(gameObject.transform.position, 150f);
        foreach (var player in players)
        {

            if (player.gameObject.GetComponent<PlayerUI>() != null)
            {
                player.gameObject.GetComponent<PlayerUI>().HideReport();
            }
        }
    }
}

