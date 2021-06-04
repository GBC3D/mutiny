using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private Text report;
    [SerializeField]
    private GameObject vote;
    [SerializeField]
    private Text tasks;
    public bool reportable = false;


    void Update()
    {
        if (reportable && Input.GetKeyDown(KeyCode.E))
        {
            StartVote();
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

    public void StartVote()
    {
        vote.gameObject.SetActive(true);
        report.gameObject.SetActive(false);
        tasks.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
    }


}
