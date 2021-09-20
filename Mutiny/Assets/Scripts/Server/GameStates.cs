using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.Video;

public class GameStates : MonoBehaviourPunCallbacks
{
    public int readyPlayers = 0;

    private int spawner = 0;

    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    private Canvas skinCanvas;

    [SerializeField]
    private Text playersText;

    [SerializeField]
    private VideoPlayer player;

    [SerializeField]
    private GameObject telePosition;

    [SerializeField]
    private Transform[] spawns;

    private void Awake()
    {
        playersText.text = "Ready players: 0/" + PhotonNetwork.CurrentRoom.PlayerCount;
    }

    private void Update()
    {
        //Debug.Log("Ready Players = " + readyPlayers.ToString() + " Connected Players = " + PhotonNetwork.CurrentRoom.PlayerCount.ToString());

        if (readyPlayers == PhotonNetwork.CurrentRoom.PlayerCount)
        {
            Debug.Log("READY PLAYERS = " + readyPlayers.ToString());
            readyPlayers = 0;
            photonView.RPC("StartGame", RpcTarget.All);

        }

        playersText.text = "Ready players: " + readyPlayers + "/" + PhotonNetwork.CurrentRoom.PlayerCount;
    }

    [PunRPC]
    public void StartGame()
    {
        Debug.Log("GAME STARTED!");
        canvas.gameObject.SetActive(false);
        skinCanvas.gameObject.SetActive(false);
        player.Play();
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
                playerPrefabObject.GetComponent<CharacterController>().enabled = false; //remove this and the other one below if it's a probelm
                playerPrefabObject.transform.position = telePosition.gameObject.transform.position;
                playerPrefabObject.GetComponent<CharacterController>().enabled = true;

                //spawner += 1;

            }
        }

        //spawner = 0;
    }

    //public void ReceiveReady()
    //{
      //  readyPlayers += 1;
    //}

 //  public void ReceiveUnready()
  //  {
    //    readyPlayers -= 1;
    //}
}
