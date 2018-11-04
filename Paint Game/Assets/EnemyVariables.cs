using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVariables : MonoBehaviour {

    public int health;

    public int speed;
    private bool facingRight;

    public GameObject splat;
    public Transform death;

    private float blinkTimer = 0;
    private float blinkTimerStart = 0.1f;

    public Animator anim;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(-speed * Time.deltaTime, 0, 0);

        if (blinkTimer > 0)
        {
            anim.SetBool("Hurt", true);
            blinkTimer -= Time.deltaTime;
        }
        else
        {
            anim.SetBool("Hurt",false);
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            if (facingRight)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                facingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                facingRight = true;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        blinkTimer = blinkTimerStart;

        if (health <= 0)
        {
            Instantiate(splat, death.position, death.rotation);
            Destroy(gameObject);
        }
    }

}
