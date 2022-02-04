using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob_Obj : Character
{
    public VidaConfig vidaConfigCastelo;
    public Transform _entrada;
    private ResourcesManager resourcesManager;

    public override void Init(Mob_Scr stats, int entrada)
    {
        base.Init(stats, entrada);
        resourcesManager = FindObjectOfType<ResourcesManager>().GetComponent<ResourcesManager>();
        vidaConfigCastelo = FindObjectOfType<CasteloStats>().GetComponent<VidaConfig>();
        GetComponent<AIDestinationSetter>().target = FindObjectOfType<Entrada>().transform.parent.GetChild(entrada);
        _entrada = FindObjectOfType<Entrada>().transform.parent.GetChild(entrada);
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
    private void Update()
    {
        if (Vector3.Distance(transform.position, _entrada.position) < 0.001f)
        {
            CausarDanoAoCastelo(); Destroy(gameObject);
        }
    }

    internal override void NaDestruicao()
    {
        base.NaDestruicao();
        SpawnRecompensa();
    }

    private void SpawnRecompensa()
    {
        resourcesManager.mobDestroyed.Invoke(_stats.recompensa, transform.position);
    }

    private void CausarDanoAoCastelo()
    {
        if (vidaConfigCastelo != null) vidaConfigCastelo.vidaAtual -= _stats.danoAoCastelo;
    }
}
