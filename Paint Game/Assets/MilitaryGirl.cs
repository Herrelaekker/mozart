using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilitaryGirl : MonoBehaviour {

    public int speed;

    private bool moving;

	// Use this for initialization
	void Start () {
        moving = true;
	}
	
	// Update is called once per frame
	void Update () {

        if (moving)
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Trigger")
        {
            moving = false;
            print("HAHA");
        }
        print("øv");
    }

}
