﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public GameObject[] projectile;
    public Transform shotPoint;

    private bool rightDirection;

    private float timeBtwShots;
    public float startTimebtwshots;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
    {
        rightDirection = GameObject.Find("Player").GetComponent<PlayerMovement>().facingRight;

        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (rightDirection)
                {
                    Instantiate(projectile[0], shotPoint.position, transform.rotation);
                }
                else
                {
                    Instantiate(projectile[1], shotPoint.position, transform.rotation);
                }
                timeBtwShots = startTimebtwshots;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
	}
}
