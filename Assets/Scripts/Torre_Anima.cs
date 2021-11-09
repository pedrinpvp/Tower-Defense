using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Torre_Anima : MonoBehaviour
{

    private Animator anim;
    private SpriteRenderer spriteRend;

    private void Start()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void MudarAnimacao(Enums.Direcoes direcoes)
    {
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
