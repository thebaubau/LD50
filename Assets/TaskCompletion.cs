using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskCompletion : MonoBehaviour
{
    private static TaskCompletion instance;

    public static TaskCompletion Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<TaskCompletion>();
            }
            return instance;
        }
    }

    class Task
    {
        public Toggle taskToggle;
        public TextMeshProUGUI taskText;
        public TMP_InputField taskInput;
        public int taskId { get; set; }
        public bool hasInput { get; set; }
        public string taskString { get; set; }
    }

    class GameTask
    {
        public int taskId { get; set; }
        public string taskString { get; set; }
        public bool hasInput { get; set; }
    }

    private List<GameTask> allTasks = new List<GameTask>();
    private Dictionary<int, Task> tasks = new Dictionary<int, Task> { };

    private bool gameDone = false;
    private int taskCount = 0;

    public int TaskCount { get => taskCount; set => taskCount = value; }

    private void OnEnable()
    {
        CreateTaskList();
        SetRoundTasks();
        AssignRoundTasks();
    }

    private void CreateTaskList()
    {
        allTasks.Add(new GameTask() { taskId = 0, taskString = "Buy a mouse from Llamazon", hasInput = false });
        allTasks.Add(new GameTask() { taskId = 1, taskString = "Turn off Monitor", hasInput = false });
        //allTasks.Add(new GameTask() { taskId = 2, taskString = "Complete the sentence:", hasInput = true });
        allTasks.Add(new GameTask() { taskId = 3, taskString = "Upgrade PC", hasInput = false });
        allTasks.Add(new GameTask() { taskId = 4, taskString = "Watch a video", hasInput = false });
        allTasks.Add(new GameTask() { taskId = 5, taskString = "Score 10 at PONG", hasInput = false });
        allTasks.Add(new GameTask() { taskId = 6, taskString = "Too much light in the room", hasInput = false });
        //allTasks.Add(new GameTask() { taskId = 7, taskString = "What is the book talking about?", hasInput = true });
        //allTasks.Add(new GameTask() { taskId = 8, taskString = "Use command line to close PC", hasInput = false });
    }

    // Update is called once per frame
    void Update()
    {
        if (taskCount == 4 && !gameDone)
        {
            gameDone = true;
            UiManager.Instance.Win();
        }
    }

    public void SetRoundTasks()
    {
        int taskCount = GetComponentsInChildren<Toggle>().Length;

        tasks.Add(0, new Task
        {
            taskToggle = GetComponentsInChildren<Toggle>()[0],
            taskText = GetComponentsInChildren<TextMeshProUGUI>()[0],
            taskInput = GetComponentsInChildren<TMP_InputField>()[0],
            taskId = allTasks[0].taskId,
            taskString = allTasks[0].taskString,
            hasInput = allTasks[0].hasInput
        });
        
        int[] arr = Enumerable.Range(1, allTasks.Count - 1).ToArray();

        for (int i = 1; i < taskCount; i++)
        {
            int randomTask = arr[UnityEngine.Random.Range(0, arr.Length)];
            arr = arr.Where(val => val != randomTask).ToArray();

            tasks.Add(i, new Task
            {
                taskToggle = GetComponentsInChildren<Toggle>()[i],
                taskText = GameObject.FindGameObjectsWithTag("Task")[i].GetComponent<TextMeshProUGUI>(),
                taskInput = GetComponentsInChildren<TMP_InputField>()[i],
                taskId = allTasks[randomTask].taskId,
                taskString = allTasks[randomTask].taskString,
                hasInput = allTasks[randomTask].hasInput
            });
        }
    }

    public void AssignRoundTasks()
    {
        for (int i = 1; i < tasks.Count; i++)
        {
            tasks[i].taskText.text = tasks[i].taskString;

            if (tasks[i].hasInput)
            {
                tasks[i].taskInput.gameObject.SetActive(true);
            } 
            else
            {
                tasks[i].taskInput.gameObject.SetActive(false);
            }
        }
    }

    public void SetTaskComplete(int id)
    {
        //Debug.Log("Updating Task");
        //Debug.Log(id + " sent Id");
        for (int i = 0; i < tasks.Count; i++)
        {
            //Debug.Log(i + " iteration");
            //Debug.Log(tasks[i].taskId + " task ID");
            
            if (tasks[i].taskId == id)
            {
                //Debug.Log(tasks[i].taskId + " activated  task ID");
                if (tasks[i].taskToggle.isOn == true) return;

                tasks[i].taskToggle.isOn = true;
                TaskCount += 1;
                return;
            }
        }
    }

    public bool MouseBought()
    {
        if (tasks[0].taskToggle.isOn)
        {
            return true;
        }
        return false;
    }

    public void IncreaseUsedTasks()
    {
        taskCount++;
    }
}
