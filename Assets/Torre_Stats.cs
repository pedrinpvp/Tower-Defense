using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torre_Stats : MonoBehaviour
{
    public Torre_Scr torre;
    public CircleCollider2D circle;

    // Start is called before the first frame update
    void Start()
    {
        circle = gameObject.GetComponent<CircleCollider2D>();
        circle.radius = torre.alcance;
    }

    // Update is called once per frame
    void Update()
    {
    }

    
}
