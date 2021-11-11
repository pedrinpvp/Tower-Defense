using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClasseTeste : MonoBehaviour
{
    public int a = 0;
    public int b = 2;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(a==b);
        Debug.Log(a!=b);
    }

}
