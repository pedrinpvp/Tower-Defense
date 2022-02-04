using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Torre_Anim : MonoBehaviour
{

    private Animator anim;
    private SpriteRenderer spriteRend;
    [SerializeField]
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
                spriteRend.flipX = false;
            }
            if (direcoes == Enums.Direcoes.baixo)
            {
                anim.SetTrigger("Front");
                spriteRend.flipX = false;
            }
            if (direcoes == Enums.Direcoes.direita)
            {
                anim.SetTrigger("Side");
                spriteRend.flipX = false;
            }
            if (direcoes == Enums.Direcoes.esquerda)
            {
                anim.SetTrigger("Side");
                spriteRend.flipX = true;
            }
        }
        
    }

    public void MoverComInimigo(Transform inimigoMaisPerto)
    {
        Vector2 positionOnScreen = transform.position;

        Vector2 inimigoOnScreen = inimigoMaisPerto.position;

        float angle = relative(inimigoOnScreen);

        SelecionarAnimacaoPorAngulo(angle);
    }

    float relative(Vector2 target)
    {
        Vector3 relative = transform.InverseTransformPoint(target);
        return Mathf.Atan2(relative.y, relative.x) * Mathf.Rad2Deg;

    }
    private void SelecionarAnimacaoPorAngulo(float angle)
    {
        if (angle > 0)
        {
            if (angle < 30)
            {
                MudarAnimacao(Enums.Direcoes.direita);
            }
            else if (angle < 120 && angle > 60)
            {
                MudarAnimacao(Enums.Direcoes.cima);
            }
            else if (angle > 150)
            {
                MudarAnimacao(Enums.Direcoes.esquerda);
            }
        }
        else if (angle < 0)
        {
            if (angle > -30)
            {
                MudarAnimacao(Enums.Direcoes.direita);
            }
            else if (angle > -120 && angle < -60)
            {
                MudarAnimacao(Enums.Direcoes.baixo);
            }
            else if (angle < -150)
            {
                MudarAnimacao(Enums.Direcoes.esquerda);
            }
        }
    }
}
