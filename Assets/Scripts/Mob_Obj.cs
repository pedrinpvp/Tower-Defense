using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob_Obj : MonoBehaviour
{
    public Mob_Scr _stats;
    public VidaConfig vidaConfigCastelo;
    public Transform _entrada;
    public VidaConfig minhaVida;
    public VidaMedidor medidor;
    public int vida;
    public void Init(Mob_Scr stats, int entrada)
    {
        Debug.Log("INITTT");
        vidaConfigCastelo = FindObjectOfType<CasteloStats>().GetComponent<VidaConfig>();
        minhaVida = GetComponent<VidaConfig>();
        medidor = GetComponent<VidaMedidor>();
        _stats = stats;
        vida = _stats.vida;
        minhaVida.vidaAtual = vida;
        minhaVida.vidaMax = vida;
        medidor.vidaConfig = minhaVida;
        medidor.follow = gameObject;
        GetComponent<AIDestinationSetter>().target = FindObjectOfType<Entrada>().transform.parent.GetChild(entrada);
        _entrada = FindObjectOfType<Entrada>().transform.parent.GetChild(entrada);
        GetComponent<AILerp>().speed = FormatarVelocidade(_stats.velocidade);
        GetComponent<Animator>().runtimeAnimatorController = _stats.animation;
        //Debug.LogWarning(_stats.name);
    }

    public void InitializeCanva()
    {
        medidor.Initialize();
    }

    float FormatarVelocidade(float velocidade)
    {
        return velocidade /= 4; 
    }
    private void Update()
    {
        if (_stats != null)
        {
            if (minhaVida != null) minhaVida.vidaAtual = vida;
            if (vida <= 0) Destroy(gameObject);
        }
        if (Vector3.Distance(transform.position, _entrada.position) < 0.001f)
        {
            CausarDano();
            Destroy(gameObject);
        }
    }

    private void CausarDano()
    {
        if (minhaVida != null) minhaVida.vidaAtual -= _stats.danoAoCastelo;
    }
}
