using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject[] winUI;
    public GameObject[] loseUI;
    public GameObject[] IntroUI;
    // Start is called before the first frame update
    void Awake()
    {
        winUI = GameObject.FindGameObjectsWithTag("WinUI");
        loseUI = GameObject.FindGameObjectsWithTag("LoseUI");
        IntroUI = GameObject.FindGameObjectsWithTag("IntroUI");
        DisableUI();
    }

    // Update is called once per frame
    void Update()
    {
        switch (LevelManager.levelStatus)
        {
            case "Playing":
                DisableTagObject(IntroUI);
                break;
            case "Win":
                EnableTagObject(winUI);
                break;
            case "Lose":
                EnableTagObject(loseUI);
                break;
        }
    }
    private void DisableTagObject(GameObject[] TagObjects)
    {
        foreach (GameObject TagObject in TagObjects)
        {
            TagObject.SetActive(false);
        }
    }
    private void DisableUI()
    {
        DisableTagObject(winUI);
        DisableTagObject(loseUI);
    }
    private void EnableTagObject(GameObject[] TagObjects)
    {
        foreach (GameObject TagObject in TagObjects)
        {
            TagObject.SetActive(true);
        }
    }
}

