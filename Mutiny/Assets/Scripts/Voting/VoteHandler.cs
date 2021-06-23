using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class VoteHandler : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text text;

    [SerializeField]
    private int votes;

    [SerializeField]
    private int totalVotes;

    [SerializeField]
    private string player = "Player 1";

    [SerializeField]
    private Button theButton;

    public PlayerUI players;

    public void Vote()
    {
        photonView.RPC("VoteRPC", RpcTarget.All);
    }

    [PunRPC]
    public void VoteRPC()
    {
        votes++;
        totalVotes++;

        text.text = "Votes " + votes.ToString();


        if (PhotonNetwork.CurrentRoom.PlayerCount == totalVotes)
        {
            photonView.RPC("EndVote", RpcTarget.All);
        }

        
    }

    [PunRPC]
    public void EndVote()
    {
        Debug.Log(player + " has been voted out!");
        votes = 0;
        totalVotes = 0;
        theButton.interactable = true;
        Debug.Log(theButton.interactable.ToString());
        GameObject.Find("GameManager/Canvas").SetActive(false);
        text.text = "Votes " + votes.ToString();
        photonView.RPC("FixUI", RpcTarget.All);
    }

    [PunRPC]
    public void FixUI()
    {
        //if (gameObject.GetComponent<PlayerUI>() != null)
        //{
        // gameObject.GetComponent<PlayerUI>().FixUI();
        //  Debug.Log("Fixed UI");
        //}


        //FOR FUTURE REFERENCE: THE CODE BELOW IS HOW YOU GET A REFERENCE
        //TO EACH PLAYER'S GAMEOBJECT IN THE SCENE. IT'S INDESCRIBABLY USEFUL.
        var photonViews = UnityEngine.Object.FindObjectsOfType<PhotonView>();
        foreach (var view in photonViews)
        {
            var player = view.Owner;
            if (player != null)
            {
                var playerPrefabObject = view.gameObject;
                playerPrefabObject.GetComponent<PlayerUI>().FixUI();
            }
        }
    }
}