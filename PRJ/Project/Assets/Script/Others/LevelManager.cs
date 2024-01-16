using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static string levelStatus;
    private EnemySpawner EnemySpawner;

    void Awake()
    {
        levelStatus = "Waiting";
        Time.timeScale = 1;
    }
    void Update()
    {
        switch (levelStatus)
        {
            case "Waiting":
                break;
            case "Playing":
                break;
            default:
                if (Input.GetMouseButtonDown(0))
                {
                    SceneManager.LoadScene(0);
                }
                break;
        }
    }
    public static void Win()
    {
        UnityEngine.Debug.Log("You Win!");
        levelStatus = "Win";
        Freeze();
    }
    public static void Lose()
    {
        UnityEngine.Debug.Log("You Lose!");
        levelStatus = "Lose";
        Freeze();

    }
    public static void StartGame()
    {
        UnityEngine.Debug.Log("StartGame");
        levelStatus = "Playing";

    }
    public static void Pause()
    {
        UnityEngine.Debug.Log("Pause");

        Freeze();
    }

    public static void Resume()
    {
        UnityEngine.Debug.Log("Resume");
    }

    public static void Restart()
    {
        UnityEngine.Debug.Log("Restart");
    }

    public static void Quit()
    {
        UnityEngine.Debug.Log("Quit");
    }

    public static void Freeze()
    {
        UnityEngine.Debug.Log("Freeze");
        Time.timeScale = 0;
    }
}
