using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Launcher : MonoBehaviourPunCallbacks
{
    //Once started, automatically sync the scene and call connect.
    public void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        Connect();
    }

    //Called as soon as you're connected to the Master server. Calls Join()
    public override void OnConnectedToMaster()
    {
        Join();

        base.OnConnectedToMaster();
    }

    //When the room is joined, run StartGame()
    public override void OnJoinedRoom()
    {
        StartGame();

        base.OnJoinedRoom();
    }

    //Only called when there are no active rooms. Creates a room and then joins that room.
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Create();

        base.OnJoinRandomFailed(returnCode, message);
    }

    //Set the current version and connect to the master server with the same version
    public void Connect()
    {
        PhotonNetwork.GameVersion = "0.0.0";
        PhotonNetwork.ConnectUsingSettings();
    }

    //Randomly joins an active room. If this fails, see OnJoinRandomFailed override. If successful, see OnJoinedRoom override
    public void Join()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    //Creates a room with name ""
    public void Create()
    {
        PhotonNetwork.CreateRoom("");
    }

    //Loads the starting scene of the game if there's one player in the room.
    public void StartGame()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            PhotonNetwork.LoadLevel(1);
        }
    }
    
}
