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
        _stats = stats;
        vida = _stats.vida;
        minhaVida.vidaAtual = vida;
        minhaVida.vidaMax = vida;
        medidor.vidaConfig = minhaVida;
        medidor.follow = gameObject;
        GetComponent<AILerp>().speed = FormatarVelocidade(_stats.velocidade);
        GetComponent<Animator>().runtimeAnimatorController = _stats.animation;
        Debug.Log(GetComponent<AILerp>().speed);
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
