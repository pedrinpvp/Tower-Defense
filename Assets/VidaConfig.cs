using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaConfig : MonoBehaviour
{
    public int vidaMax;
    public int vidaAtual;
    // Start is called before the first frame update
    void Awake()
    {
        vidaAtual = vidaMax;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
