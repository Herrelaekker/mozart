using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gay : MonoBehaviour {

    private PlayerMovement player;

    private bool nearbyWall;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
            nearbyWall = true;

        if (other.gameObject.tag == "Red" && nearbyWall || other.gameObject.tag == "Red Floor" && nearbyWall)
        {
            player.TakeDamge(1);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
            nearbyWall = false;
    }

}
