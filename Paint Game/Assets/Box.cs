using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {

    private PlayerMovement player;

    public Sprite[] boxState;
    private SpriteRenderer boxSprite;
    public int state;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        boxSprite = GetComponentInParent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        boxSprite.sprite = boxState[state];
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Blue")
        {
            if (state != 0)
            state -= 1;
        }

        if (other.gameObject.tag == "Player" && state > 0)
        {
            player.TakeDamge(1);
        }
    }

}
