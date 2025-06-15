using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Rigidbody2D rig;
    public float xAxis;
    public float yAxis;
    private Player player;
    public int damage;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.AddForce(new Vector2(xAxis, yAxis), ForceMode2D.Impulse);

        Destroy(gameObject, 4f);

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            player.OnHit(damage);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
