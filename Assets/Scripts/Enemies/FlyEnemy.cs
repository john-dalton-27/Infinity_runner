using UnityEngine;

public class FlyEnemy : Enemy
{
    private Rigidbody2D rig;
    public float speed;
    protected override void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5f);
        base.Start();
    }


    void Update()
    {
        rig.linearVelocity = new Vector2(-speed, 0);
    }
}
