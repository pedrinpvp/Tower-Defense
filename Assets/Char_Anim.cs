using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Char_Anim : MonoBehaviour
{
    public AnimacoesBasicas animacoes = AnimacoesBasicas.Idle;
    protected Animator animator;
    protected AnimatorOverrideController overrideController;


    public void Init(AnimationClip idle, AnimationClip run, AnimationClip shoot, AnimationClip death)
    {
        animator = GetComponent<Animator>();
        overrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = overrideController;
        overrideController["Idle"] = idle;
        overrideController["Run"] = run;
        overrideController["Shoot"] = shoot;
        overrideController["Death"] = death;
    }
}

public enum AnimacoesBasicas 
{
    Idle,
    Run,
    Shoot,
    Death
}

