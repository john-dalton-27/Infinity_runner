using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rig;
    public float speed;
    public int damage;
    public GameObject explosionPrefab;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 0.7f);
    }

    private void FixedUpdate()
    {
        rig.linearVelocity = Vector2.right * speed;
    }

    public void OnHit()
    {
        GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(explosion, .5f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            OnHit();
            Destroy(gameObject);
        }
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

}
