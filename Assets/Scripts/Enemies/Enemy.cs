using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int damage;
    public GameObject playerObj;
    public Player player;

    protected virtual void Start()
{
    playerObj = GameObject.FindGameObjectWithTag("Player");

    if (playerObj != null)
    {
        player = playerObj.GetComponent<Player>();
    }
    else
    {
        Debug.LogError("Enemy: Player não encontrado! Verifique se ele tem a tag 'Player'.");
    }
}

    public virtual void ApplyDamage(int dmg)
    {
        health -= dmg;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D colision)
    {
        if(colision.CompareTag("Bullet"))
        {
            ApplyDamage(colision.GetComponent<Projectile>().damage);
            colision.GetComponent<Projectile>().OnHit();
        }

        if(colision.CompareTag("Player"))
        {
            if(player == null)
            {
                Debug.LogError("player está nulo!");
            }
            else
            {
            player.OnHit(damage);
            }
        }
    }
}
