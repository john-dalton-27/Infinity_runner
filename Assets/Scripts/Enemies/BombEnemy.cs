using UnityEngine;

public class BombEnemy : Enemy
{
    public GameObject bombPrefab;
    public float throwTime;
    private float throwCount;
    public Transform firePoint;

    void Update()
    {
        throwCount += Time.deltaTime;

        if(throwCount >= throwTime)
        {
            Instantiate(bombPrefab, firePoint.position, firePoint.rotation);
            throwCount = 0f;
        }
    }
}
