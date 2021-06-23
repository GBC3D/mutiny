using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class Voting : MonoBehaviourPunCallbacks
{
    [SerializeField]
    public Text text;

    [SerializeField]
    public int votes = 0;


    public void Vote()
    {
        votes++;
        text.text = "Votes " + votes.ToString();

        photonView.RPC("VoteRPC", RpcTarget.All, text);
    }

    [PunRPC]
    public void VoteRPC(string input)
    {
        text.text = input;
    }
}