using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameStates : MonoBehaviourPunCallbacks
{
    public int readyPlayers = 0;

    private void Update()
    {
        Debug.Log("Ready Players = " + readyPlayers.ToString() + " Connected Players = " + PhotonNetwork.CurrentRoom.PlayerCount.ToString());

        if (readyPlayers == PhotonNetwork.CurrentRoom.PlayerCount)
        {
            Debug.Log("READY PLAYERS = " + readyPlayers.ToString());
            readyPlayers = 0;
            photonView.RPC("StartGame", RpcTarget.All);

        }
    }

    [PunRPC]
    public void StartGame()
    {
        Debug.Log("GAME STARTED!");
        var photonViews = UnityEngine.Object.FindObjectsOfType<PhotonView>();
        foreach (var view in photonViews)
        {
            var player = view.Owner;
            if (player != null)
            {
                var playerPrefabObject = view.gameObject;
                playerPrefabObject.GetComponent<PlayerUI>().enabled = true;
                playerPrefabObject.GetComponent<TaskAssigner>().enabled = true;
                Debug.Log("FORTNITE MAN IT WORKS OR SOMETHING");

            }
        }
    }
}
