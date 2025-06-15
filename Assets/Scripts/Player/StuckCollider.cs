using System;
using UnityEngine;

public class StuckCollider : MonoBehaviour
{
    private float stuckTime = 0f;
    public float maxStuckTime = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Platform"))
        {
            stuckTime = 0f;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Platform"))
        {
            stuckTime += Time.deltaTime;
            if(stuckTime >= maxStuckTime)
            {
                GameManager.instance.showGameOver();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        stuckTime = 0f;
    }
}
