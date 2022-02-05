using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Char_Scr : ScriptableObject
{
    private string nome;
    public int vida = 10;
    public int dano = 3;

    [Header("Quantos metros anda por segundo")]
    public float velocidade = 3;

    [Header("Imagem do inimigo")]
    public AnimatorController animation;

    private void OnValidate()
    {
        nome = name;
    }
}
