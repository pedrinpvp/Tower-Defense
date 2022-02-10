using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using static Enums;

public class Char_Anim : MonoBehaviour
{
    public AnimacoesBasicas animacoes = AnimacoesBasicas.Idle;
    protected Animator animator;
    public bool activate;
    public void Init(AnimatorOverrideController overrideController)
    {
        animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = overrideController;
    }
    public void ChangeAnim(AnimacoesBasicas animacao)
    {
        animacoes = animacao;
        foreach (var anim in animator.parameters)
        {
            //If matching names set parameter to true
            animator.SetBool(anim.name, anim.name == animacao.ToString());
        }
        animator.SetBool(animacao.ToString(), true);
    }
}

