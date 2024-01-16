using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartObject : MonoBehaviour
{
    private Attribute Attribute;
    private EnemySpawner EnemySpawner;

    // Start is called before the first frame update
    void Start()
    {
        Attribute = GetComponent<Attribute>();
        GameObject enemySpawner = GameObject.FindGameObjectWithTag("EnemySpawner");
        if (enemySpawner != null)
        {
            EnemySpawner = enemySpawner.GetComponent<EnemySpawner>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckDied();
    }

    private void CheckDied()
    {
        if (Attribute.Health <= 0)
        {
                LevelManager.StartGame();
                EnemySpawner.startSpawning();
                Destroy(gameObject);
        }
    }
}
