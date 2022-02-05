using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : Character
{
    public VidaConfig vidaConfigCastelo;
    public Transform _entrada;
    private ResourcesManager resourcesManager;
    private Mob_Scr stats;

    public override void Init(Char_Scr stats, int entrada)
    {
        base.Init(stats, entrada);
        stats = _stats as Mob_Scr;
        resourcesManager = FindObjectOfType<ResourcesManager>().GetComponent<ResourcesManager>();
        vidaConfigCastelo = FindObjectOfType<CasteloStats>().GetComponent<VidaConfig>();
        GetComponent<AIDestinationSetter>().target = FindObjectOfType<Entrada>().transform.parent.GetChild(entrada);
        _entrada = FindObjectOfType<Entrada>().transform.parent.GetChild(entrada);
        FliparDeAcordoComTarget(_entrada);
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
        resourcesManager.mobDestroyed.Invoke(stats.recompensa, transform.position);
    }

    private void CausarDanoAoCastelo()
    {
        if (vidaConfigCastelo != null) vidaConfigCastelo.vidaAtual -= stats.danoAoCastelo;
    }
}
