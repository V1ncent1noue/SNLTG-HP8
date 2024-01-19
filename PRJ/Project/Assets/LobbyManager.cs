using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{

    public GameObject lobbyAnimation;
    public float resetTime = 5f;
    private float time = 0f;
    public Transform leftLocation;
    public Transform rightLocation;
    public float speed = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= resetTime)
        {
            time = 0f;
            setLocationToLeft();
        }
        moveToRight();
    }

    void moveToLeft()
    {
        lobbyAnimation.transform.position = Vector2.MoveTowards(lobbyAnimation.transform.position, leftLocation.position, speed);
    }

    void moveToRight()
    {
        lobbyAnimation.transform.position = Vector2.MoveTowards(lobbyAnimation.transform.position, rightLocation.position, speed);
    }

    void setLocationToLeft()
    {
        lobbyAnimation.transform.position = leftLocation.position;
    }

}
