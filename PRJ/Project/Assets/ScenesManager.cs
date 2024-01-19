using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{

    [SerializeField] private int currentLevelIndex;
    private int maxLevelIndex;


    private void Start()
    {
        maxLevelIndex = SceneManager.sceneCountInBuildSettings - 1;
        currentLevelIndex = SceneManager.GetActiveScene().buildIndex;

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentLevelIndex == 0)
        {
            LoadLevel(1);
        }
        if (Input.GetMouseButtonDown(0) && LevelManager.levelStatus == "Win")
        {
            LoadLobby();
        }
        if (Input.GetMouseButtonDown(0) && LevelManager.levelStatus == "Lose")
        {
            ReloadLevel();
        }
    }


    public void LoadNextLevel()
    {
        int nextLevelIndex = currentLevelIndex + 1;
        if (nextLevelIndex > maxLevelIndex)
        {
            nextLevelIndex = 0; // Loop back to the lobby if there are no more levels
        }

        LoadLevel(nextLevelIndex);
    }

    public void LoadPreviousLevel()
    {
        int previousLevelIndex = currentLevelIndex - 1;
        if (previousLevelIndex < 0)
        {
            previousLevelIndex = maxLevelIndex; // Wrap around to the last level if at the lobby
        }

        LoadLevel(previousLevelIndex);
    }

    public void ReloadLevel()
    {
        LoadLevel(currentLevelIndex);
    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    public void LoadLobby()
    {
        LoadLevel(0);
    }
}
