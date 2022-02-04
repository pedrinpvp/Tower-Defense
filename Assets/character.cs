using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Character : MonoBehaviour
{
    public Mob_Scr _stats;
    public VidaConfig minhaVida;
    public VidaMedidor medidor;
    public int vida;
    public virtual void Init(Mob_Scr stats, int entrada)
    {
        minhaVida = GetComponent<VidaConfig>();
        medidor = GetComponent<VidaMedidor>();
        _stats = stats;
        vida = _stats.vida;
        minhaVida.vidaAtual = vida;
        minhaVida.vidaMax = vida;
        medidor.vidaConfig = minhaVida;
        medidor.follow = gameObject;
        GetComponent<AILerp>().speed = FormatarVelocidade(_stats.velocidade);
        GetComponent<Animator>().runtimeAnimatorController = _stats.animation;
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
            ValidarVida();
            if (vida <= 0)
            {
                NaDestruicao();
            }
        }
    }

    internal virtual void ValidarVida()
    {
        if (minhaVida != null) minhaVida.vidaAtual = vida;
    }

    internal virtual void NaDestruicao()
    {
        Destroy(gameObject);
    }
}
