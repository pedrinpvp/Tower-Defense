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
    private ResourcesManager resourcesManager;
    public int vida;
    public void Init(Mob_Scr stats, int entrada)
    {
        //Debug.Log("INITTT");
        resourcesManager = FindObjectOfType<ResourcesManager>().GetComponent<ResourcesManager>();
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
        IdentificarPosicaoReferenteAEntrada();
    }

    public void IdentificarPosicaoReferenteAEntrada()
    {
        //Estou na direita, e a entrada está à minha esquerda
        if(_entrada.position.x < transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else //Estou à esquerda, e a entrada está à minha direita
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
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
            if (vida <= 0)
            {
                SpawnRecompensa(); Destroy(gameObject);
            }
            
        }
        if (Vector3.Distance(transform.position, _entrada.position) < 0.001f)
        {
            CausarDano(); Destroy(gameObject);
        }
    }

    private void SpawnRecompensa()
    {
        resourcesManager.mobDestroyed.Invoke(_stats.recompensa, transform.position);
    }

    private void CausarDano()
    {
        if (vidaConfigCastelo != null) vidaConfigCastelo.vidaAtual -= _stats.danoAoCastelo;
    }
}
