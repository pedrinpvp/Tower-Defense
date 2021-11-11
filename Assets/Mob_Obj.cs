using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob_Obj : MonoBehaviour
{
    public Mob_Scr _stats;
    public int vida;
    public void Init(Mob_Scr stats, int entrada)
    {
        _stats = stats;
        vida = _stats.vida;
        GetComponent<AIDestinationSetter>().target = FindObjectOfType<Entrada>().transform.parent.GetChild(entrada);
        GetComponent<AILerp>().speed = FormatarVelocidade(_stats.velocidade);
        //Debug.LogWarning(_stats.name);
    }
    float FormatarVelocidade(float velocidade)
    {
        return velocidade /= 4; 
    }
    private void Update()
    {
        if (_stats != null)
        {
            if (vida <= 0) Destroy(gameObject);
        }
    }
}
