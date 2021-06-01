using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskAssigner : MonoBehaviour
{
    public Tasks currentTask;

    Tasks[] tasks = new Tasks[5];

    public Text taskList;

    public enum Tasks
    {
        TurnWheel,
        WashDeck,
        Spyglass,
        Dance,
        EatIceCream
    }

    // Start is called before the first frame update
    void Start()
    {
        AssignTasks();
        ResetText();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            CompleteTask();
        }
    }

    private void AssignTasks()
    {


        for (int i = 0; i < 5; i++)
        {
            tasks[i] = (Tasks)Random.Range(0, 5);
            Debug.Log(tasks[i]);
        }

        currentTask = tasks[0];

        Debug.Log("Current Task: " + currentTask);

    }

    private void CompleteTask()
    {
        if(tasks.Length > 1)
        {
            Tasks[] holderTasks = new Tasks[tasks.Length - 1];

            for (int i = holderTasks.Length; i > 0; i--)
            {
                holderTasks[i - 1] = tasks[i]; // i- 1
            }

            tasks = holderTasks;

            currentTask = tasks[0];

            Debug.Log("Current Task: " + currentTask);

            ResetText();
        } 
        else
        {
            Debug.Log("All tasks complete!");
            taskList.text = "All tasks complete!";
        }

        

    }

    private void ResetText()
    {
        Tasks condition = currentTask;

        switch (currentTask)
        {
            case Tasks.TurnWheel:
                taskList.text = "Current Task: Turn the wheel.";
                break;
            case Tasks.WashDeck:
                taskList.text = "Current Task: Wash the deck.";
                break;
            case Tasks.Spyglass:
                taskList.text = "Current Task: Use the spyglass.";
                break;
            case Tasks.Dance:
                taskList.text = "Current Task: Break it down!";
                break;
            case Tasks.EatIceCream:
                taskList.text = "Current Task: Enjoy some ice cream.";
                break;
            default:
                taskList.text = "All tasks complete!";
                break;
        }

    }
}
