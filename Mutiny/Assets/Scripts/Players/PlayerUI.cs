using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class PlayerUI : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text report;
    [SerializeField]
    private GameObject vote;
    [SerializeField]
    private Text tasks;
    public bool reportable = false;


    private void Start()
    {
        if (photonView.IsMine)
        {
            //report = GameObject.Find("Player UI/Body Report Text").GetComponent<Text>();
            //vote = GameObject.Find("Player UI/Vote Screen");
            //tasks = GameObject.Find("Player UI/Task Text").GetComponent<Text>();

            //report.gameObject.SetActive(false);
            //vote.gameObject.SetActive(false);
        }

        if (vote == null)
            Debug.LogError("SomeVariable has not been assigned.", this);
        // Notice, that we pass 'this' as a context object so that Unity will highlight this object when clicked.

    }

    private void Awake()
    {
        if (photonView.IsMine)
        {
            //report = GameObject.Find("Player UI/Body Report Text").GetComponent<Text>();
            //vote = GameObject.Find("Player UI/Vote Screen");
            //tasks = GameObject.Find("Player UI/Task Text").GetComponent<Text>();

            //report.gameObject.SetActive(false);
            //vote.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (reportable && Input.GetKeyDown(KeyCode.E))
        {
            //StartVote();
            //PhotonView view;
            //view = gameObject.transform.parent.gameObject.GetComponent<PhotonView>();
            photonView.RPC("StartVote", RpcTarget.All);
        }
    }

    public void ShowReport()
    {
        report.gameObject.SetActive(true);
        reportable = true;
    }

    public void HideReport()
    {
        report.gameObject.SetActive(false);
        reportable = false;
    }

    [PunRPC]
    public void StartVote()
    {
        vote.gameObject.SetActive(true);
        report.gameObject.SetActive(false);
        tasks.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
    }


}
