using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ReadyHandler : MonoBehaviourPunCallbacks
{

    public GameStates server;

    public Button thisButton;

    private bool isReady = false;

    private void Awake()
    {
        server = GameObject.Find("GameManager").GetComponent<GameStates>();
    }

    public void ReadyButton()
    {
        if (!isReady)
        {
            isReady = true;
            photonView.RPC("ReceiveReady", RpcTarget.All);
            Debug.Log(server.readyPlayers);
        }
        else
        {
            isReady = false;
            photonView.RPC("ReceiveUnready", RpcTarget.All);
            Debug.Log(server.readyPlayers);
        }
    }

    [PunRPC]
    public void ReceiveReady()
    {
      server.readyPlayers += 1;
    }

    [PunRPC]
    public void ReceiveUnready()
    {
      server.readyPlayers -= 1;
    }
}
