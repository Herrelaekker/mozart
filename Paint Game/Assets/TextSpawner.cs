using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSpawner : MonoBehaviour
{

    public GameObject TextPrefab;
    private Image Bar;

    // Use this for initialization
    void Start()
    {
        Bar = Instantiate(TextPrefab, FindObjectOfType<Canvas>().transform).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        Bar.transform.position = Camera.main.WorldToScreenPoint(transform.position);
    }
}
