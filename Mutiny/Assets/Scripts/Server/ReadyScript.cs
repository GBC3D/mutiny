using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ReadyScript : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private bool ready = false;

    public GameStates server;

    private void Awake()
    {
        server = GameObject.Find("GameManager").GetComponent<GameStates>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !ready)
        {
            ready = true;
            photonView.RPC("ReadyUp", RpcTarget.MasterClient);
        }
        else if (Input.GetKeyDown(KeyCode.E) && ready)
        {
            ready = false;
            photonView.RPC("UnReadyUp", RpcTarget.MasterClient);
        }
    }

    //[PunRPC]
    //private void ReadyUp()
    //{
        //server.readyPlayers += 1;
      //  server.ReceiveReady();
    //} 

    //[PunRPC]
    //private void UnReadyUp()
    //{
        //server.readyPlayers -= 1;
      //  server.ReceiveUnready();
    //}
}
