using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public int health;
    private Rigidbody2D rig;
    public Animator anim;
    public float speed;
    public float jumpForce;
    private int jumpCount;
    public int maxJumps;
    private bool isJumping;
    public GameObject bulletPrefab;
    public Transform firePoint;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        jumpCount = 0;
        maxJumps = 2;
    }

    void FixedUpdate()
    {
        rig.linearVelocity = new Vector2(speed, rig.linearVelocityY);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }

        if(Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps)
        {
            rig.linearVelocity = new Vector2(speed, 0);
            rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            anim.SetBool("jumping", true);
            jumpCount++;
        }
    }

    public void playerShoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    public void playerJump()
    {
        if(jumpCount < maxJumps)
        {
        rig.linearVelocity = new Vector2(speed, 0);
        rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        anim.SetBool("jumping", true);
        jumpCount++;
        }
    }

    public void OnHit(int dmg)
    {
        health -= dmg;

        if(health <= 0)
        {
            GameManager.instance.showGameOver();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            anim.SetBool("jumping", false);
            jumpCount = 0;
        }
    }
}
