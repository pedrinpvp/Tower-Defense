using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Character : MonoBehaviour
{
    public Char_Scr _stats;
    public VidaConfig minhaVida;
    public VidaMedidor medidor;
    public int vida;
    private SpriteRenderer spr;
    protected AILerp aiLerp;
    protected Char_Anim anim;
    //TODO: Init overloading is a poor solution
    public virtual void Init(Char_Scr stats, int entrada)
    {
        Init(stats);
    }

    public virtual void Init(Char_Scr stats)
    {
        minhaVida = GetComponent<VidaConfig>();
        medidor = GetComponent<VidaMedidor>();
        spr = GetComponent<SpriteRenderer>();
        aiLerp = GetComponent<AILerp>();
        anim = GetComponent<Char_Anim>();
        _stats = stats;
        Debug.Log(_stats.name);
        vida = _stats.vida;
        minhaVida.vidaAtual = vida;
        minhaVida.vidaMax = vida;
        medidor.vidaConfig = minhaVida;
        medidor.follow = gameObject;
        aiLerp.speed = FormatarVelocidade(_stats.velocidade);
        anim.Init(_stats.animatorOverride);
    }

    public void InitializeCanva()
    {
        medidor.Initialize();
    }

    float FormatarVelocidade(float velocidade)
    {
        return velocidade /= 4; 
    }

    protected virtual void LifeCheck()
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

    protected virtual void ValidarVida()
    {
        if (minhaVida != null) minhaVida.vidaAtual = vida;
    }

    protected virtual void NaDestruicao()
    {
        Destroy(gameObject);
    }

    public virtual void FliparDeAcordoComTarget(Transform target)
    {
        //Estou na direita, e a entrada está à minha esquerda
        if (target.position.x < transform.position.x)
        {
            spr.flipX = true;
        }
        else //Estou à esquerda, e a entrada está à minha direita
        {
            spr.flipX = false;
        }
    }
}
