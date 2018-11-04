using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    [SerializeField]
    private Stat paint;

    public GameObject[] projectile;
    public Transform shotPoint;

    private bool rightDirection;

    private float timeBtwShots;
    public float startTimebtwshots;

    private void Awake()
    {
        paint.Initialize();
    }

    // Update is called once per frame
    void Update ()
    {
        rightDirection = GameObject.Find("Player").GetComponent<PlayerMovement>().facingRight;
        if (paint.CurVal > 0)
        {
            if (timeBtwShots <= 0)
            {
                if (Input.GetButton("Fire1"))
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

                    paint.CurVal -= 1;
                }
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
	}
}
