using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class SpawnPlatform : MonoBehaviour
{
    public List<GameObject>  platforms = new List<GameObject>();
    private List<Transform> currentPlatforms = new List<Transform>();
    private Transform player;
    private Transform currentPlatformPoint;
    private int platformIndex;
    public float offset;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        for(int i = 0; i < platforms.Count; i++)
        {
            Transform p = Instantiate(platforms[i], new Vector2(i * 30,-4.3f), transform.rotation).transform;
            currentPlatforms.Add(p);
            offset += 30f;
        }

        currentPlatformPoint = currentPlatforms[platformIndex].GetComponent<Platform>().finalPoint;
    }

    public void Pooling(GameObject platform)
    {
        platform.transform.position = new Vector2(offset, -4.3f);
        if(platform.GetComponent<Platform>().spawnObj != null)
        {
            platform.GetComponent<Platform>().spawnObj.Spawn();
        }
        offset += 30;
    }


    void Update()
    {
        Move();
    }

    void Move()
    {
        float distance = player.position.x - currentPlatformPoint.position.x;
        if(distance >= 1)
        {
            Pooling(currentPlatforms[platformIndex].gameObject);
            platformIndex++;

            if(platformIndex > currentPlatforms.Count -1)
            {
                platformIndex = 0;
            }
            currentPlatformPoint = currentPlatforms[platformIndex].GetComponent<Platform>().finalPoint;
        }
    }
}
