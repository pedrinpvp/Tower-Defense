using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Torre_Anim : MonoBehaviour
{

    private Animator anim;
    private SpriteRenderer spriteRend;
    private Enums.Direcoes direcaoAtual;
    private void Start()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void MudarAnimacao(Enums.Direcoes direcoes)
    {
        if (direcaoAtual != direcoes)
        {
            direcaoAtual = direcoes;
            //Debug.Log(direcoes.ToString());
            if (direcoes == Enums.Direcoes.cima)
            {
                anim.SetTrigger("Back");
                GetComponent<SpriteRenderer>().flipX = false;
            }
            if (direcoes == Enums.Direcoes.baixo)
            {
                anim.SetTrigger("Front");
                GetComponent<SpriteRenderer>().flipX = false;
            }
            if (direcoes == Enums.Direcoes.direita)
            {
                anim.SetTrigger("Side");
                GetComponent<SpriteRenderer>().flipX = false;
            }
            if (direcoes == Enums.Direcoes.esquerda)
            {
                anim.SetTrigger("Side");
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        
    }
}
