using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gay : MonoBehaviour {

    private PlayerMovement player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Red" || other.gameObject.tag == "Red Floor")
        {
            if (GetComponentInParent<PlayerMovement>().isGrounded)
                player.TakeDamge(1);
        }
    }

}
