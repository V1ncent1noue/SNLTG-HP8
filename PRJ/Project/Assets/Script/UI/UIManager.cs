using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static GameObject[] winUI;
    public static GameObject[] loseUI;
    public static GameObject[] IntroUI;
    public static GameObject[] BossHealthBar;
    public static GameObject[] PlayerHealthBar;
    // Start is called before the first frame update
    void Awake()
    {
        winUI = GameObject.FindGameObjectsWithTag("WinUI");
        loseUI = GameObject.FindGameObjectsWithTag("LoseUI");
        IntroUI = GameObject.FindGameObjectsWithTag("IntroUI");
        BossHealthBar = GameObject.FindGameObjectsWithTag("BossHealthBar");
        PlayerHealthBar = GameObject.FindGameObjectsWithTag("PlayerHealthBar");
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
                disableHealthBar();
                break;
            case "Lose":
                EnableTagObject(loseUI);
                disableHealthBar();
                break;
        }
    }
    public static void DisableTagObject(GameObject[] TagObjects)
    {
        foreach (GameObject TagObject in TagObjects)
        {
            TagObject.SetActive(false);
        }
    }
    public static void DisableUI()
    {
        DisableTagObject(winUI);
        DisableTagObject(loseUI);
        DisableTagObject(BossHealthBar);
    }
    public static void EnableTagObject(GameObject[] TagObjects)
    {
        foreach (GameObject TagObject in TagObjects)
        {
            TagObject.SetActive(true);
        }
    }

    public static void EnableBossHealthBar()
    {
        EnableTagObject(BossHealthBar);
    }

    public static void disableHealthBar()
    {
        DisableTagObject(PlayerHealthBar);
        DisableTagObject(BossHealthBar);

    }
}

