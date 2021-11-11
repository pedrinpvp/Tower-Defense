using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Mob", menuName = "Tower Defense/Mob", order = 2)]
public class Mob_Scr : ScriptableObject
{
    private string nome;
    public int danoAoCastelo = 3;
    public int vida = 10;
    [Header("Quantos metros anda por segundo")]
    public float velocidade = 3;
    private void OnValidate()
    {
        nome = name;
    }
}
