using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public Vector2 speed;

    Rigidbody2D rb;

    public float lifeTime;

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
}
