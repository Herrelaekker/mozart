using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    private PlayerMovement player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        player.TakeDamge(1);
    }
}
