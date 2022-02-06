using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Torre_Anim : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Enums.Direcoes direcaoAtual;

    public void Init(AnimatorOverrideController overrideController)
    {
        animator.runtimeAnimatorController = overrideController;
    }

    public void MudarAnimacao(Enums.Direcoes direcoes)
    {
        if (direcaoAtual != direcoes)
        {
            direcaoAtual = direcoes;
            //Debug.Log(direcoes.ToString());
            if (direcoes == Enums.Direcoes.cima)
            {
                animator.SetTrigger("Back");
                spriteRenderer.flipX = false;
            }
            if (direcoes == Enums.Direcoes.baixo)
            {
                animator.SetTrigger("Front");
                spriteRenderer.flipX = false;
            }
            if (direcoes == Enums.Direcoes.direita)
            {
                animator.SetTrigger("Side");
                spriteRenderer.flipX = false;
            }
            if (direcoes == Enums.Direcoes.esquerda)
            {
                animator.SetTrigger("Side");
                spriteRenderer.flipX = true;
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
