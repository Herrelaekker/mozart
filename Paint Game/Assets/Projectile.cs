using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public Vector2 speed;
    public int damage;

    Rigidbody2D rb;
    public float lifeTime;
    public GameObject splat;
    public Transform death;

	// Use this for initialization
	void Start () {
        Invoke("DestroyProjectile", lifeTime);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = speed;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = speed;
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Instantiate(splat, death.position, death.rotation);
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<EnemyVariables>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Solid")
            Destroy(gameObject);

        if (other.gameObject.tag == "Red")
        {
            Destroy(other.GetComponent<Collider2D>());
        }
        
    }

}
