using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemiesPlatform : MonoBehaviour
{
    public GameObject enemyPrefab;

    public GameObject currentEnemy;

    public List<Transform> points = new List<Transform>();

    void Start()
    {
        CreateEnemy();
    }
    public void Spawn()
    {
        if(currentEnemy != null)
        {
            Destroy(currentEnemy);
        }
        CreateEnemy();
    }

    void CreateEnemy()
    {
        int pos = Random.Range(0, points.Count);
        currentEnemy = Instantiate(enemyPrefab,points[pos].position, points[pos].rotation);
    }
}
