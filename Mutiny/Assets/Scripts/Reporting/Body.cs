using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    [SerializeField]
    private LayerMask playerMask;

    void OnTriggerExit(Collider other)
    {
        HidePlayers();
    }

    void OnTriggerEnter(Collider other)
    {
        ShowPlayers();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (Physics.CheckSphere(gameObject.transform.position, 5f, playerMask))
    //    {
    //        ShowPlayers();
    //  }
    //}

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

