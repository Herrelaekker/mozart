﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public Sprite[] healthState;
    public Image healthUI;
    private SpriteRenderer playerHead;

    private PlayerMovement player;

    private float fillAmount;

    [SerializeField]
    private float lerpSpeed;

    [SerializeField]
    private Image content;

    public float maxValue { get; set; }

    public float Value
    {
        set
        {
            fillAmount = Map(value, 0, maxValue, 0, 1);
        }
    }

    // Use this for initialization
    void Start () {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        playerHead = GameObject.Find("Head").GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        healthUI.sprite = healthState[player.curHealth];
        playerHead.sprite = healthState[player.curHealth];

        Handlebar();
	}

    private void Handlebar()
    {
        if (fillAmount != content.fillAmount)
            content.fillAmount = Mathf.Lerp(content.fillAmount, fillAmount, Time.deltaTime * lerpSpeed);
    }

    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
