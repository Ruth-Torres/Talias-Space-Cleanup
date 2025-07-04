using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    public float hoizontal_speed = 0.2f;
    public float vertical_speed = 0.2f;
    private Renderer re;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        re = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(hoizontal_speed * Time.time, vertical_speed * Time.time);
        re.material.mainTextureOffset = offset;
    }
}
