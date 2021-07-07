using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyScript : MonoBehaviour
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
            server.readyPlayers += 1;
        }
        else if (Input.GetKeyDown(KeyCode.E) && ready)
        {
            ready = false;
            server.readyPlayers -= 1;
        }
    }
}
