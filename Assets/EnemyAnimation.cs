using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public AnimacoesBasicas animacoes = AnimacoesBasicas.Idle;
    public Animator animator;
    public AnimatorController animatorController;
    public AnimationClip idle;
    public AnimationClip run;
    public AnimationClip shoot;
    public AnimationClip death;

    private void Start()
    {
        animator = GetComponent<Animator>();
        //DefinirAnimacoes();
    }

    private void DefinirAnimacoes()
    {
        // -> Pegar os espaços do Animator Idle, Run, Shoot e Death, e aplicar as animações que eu salvei nesse script. Aí, cada inimigo tem sua própria versão.
        var states = animatorController.layers[0].stateMachine.states;

        foreach (var state in states)
        {
            if(state.state.name == "Idle")
            {
                state.state.motion = idle;
            }
            if (state.state.name == "Run")
            {
                state.state.motion = run;
            }
            if (state.state.name == "Shoot")
            {
                state.state.motion = shoot;
            }
            if (state.state.name == "Death")
            {
                state.state.motion = death;
            }
        }
    }

    private void Update()
    {
        if (animacoes == AnimacoesBasicas.Idle)
            animator.Play("Idle");
        if (animacoes == AnimacoesBasicas.Run)
            animator.Play("Run");
        if (animacoes == AnimacoesBasicas.Shoot)
            animator.Play("Shoot");
        if (animacoes == AnimacoesBasicas.Death)
            animator.Play("Death");

    }
}

public enum AnimacoesBasicas 
{
    Idle,
    Run,
    Shoot,
    Death
}

