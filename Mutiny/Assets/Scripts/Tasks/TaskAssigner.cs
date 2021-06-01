using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskAssigner : MonoBehaviour
{
    public Tasks currentTask;

    Tasks[] tasks = new Tasks[5];

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
        } 
        else
        {
            Debug.Log("All tasks complete!");
        }

    }
}
