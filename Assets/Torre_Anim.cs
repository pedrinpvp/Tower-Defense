using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using static Enums;

public class Torre_Anim : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Direcoes direcaoAtual;
    [SerializeField] private AnimacoesBasicas animacoes = AnimacoesBasicas.Idle;

    public void Init(AnimatorOverrideController overrideController)
    {
        animator.runtimeAnimatorController = overrideController;
    }

    public void MudarDirecao(Direcoes direcao)
    {
        if (direcaoAtual != direcao)
        {
            direcaoAtual = direcao;
            //Debug.Log(direcoes.ToString());
            if (direcao == Direcoes.cima)
            {
                animator.SetTrigger("Back");
                spriteRenderer.flipX = false;
            }
            if (direcao == Direcoes.baixo)
            {
                animator.SetTrigger("Front");
                spriteRenderer.flipX = false;
            }
            if (direcao == Direcoes.direita)
            {
                animator.SetTrigger("Side");
                spriteRenderer.flipX = false;
            }
            if (direcao == Direcoes.esquerda)
            {
                animator.SetTrigger("Side");
                spriteRenderer.flipX = true;
            }
        }
        
    }

    public void MudarEstado(AnimacoesBasicas estado)
    {
        animacoes = estado;
        foreach (var anim in animator.parameters)
        {
            //If matching names set parameter to true
            animator.SetBool(anim.name, anim.name == estado.ToString());
        }
        animator.SetBool(estado.ToString(), true);
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
                MudarDirecao(Direcoes.direita);
            }
            else if (angle < 120 && angle > 60)
            {
                MudarDirecao(Direcoes.cima);
            }
            else if (angle > 150)
            {
                MudarDirecao(Direcoes.esquerda);
            }
        }
        else if (angle < 0)
        {
            if (angle > -30)
            {
                MudarDirecao(Direcoes.direita);
            }
            else if (angle > -120 && angle < -60)
            {
                MudarDirecao(Direcoes.baixo);
            }
            else if (angle < -150)
            {
                MudarDirecao(Direcoes.esquerda);
            }
        }
    }
}
