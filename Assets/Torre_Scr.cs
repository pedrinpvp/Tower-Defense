using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Torre", menuName = "Tower Defense/Torre", order = 1)]
public class Torre_Scr : ScriptableObject
{
    private string nome;
    public int dano = 3;
    public int custo = 5;
    public float alcance = 4;
    [Header("Tiros por segundo")]
    public float cadencia = 1f;
    [Header("Quanto maior, mais dificil acertar um critico")]
    public int critChance = 10;
    [Header("Quanto maior mais rapido")]
    public float velocidadeBala = 8;
    [Header("Bala utilizada.")]
    public Bala_Scr bala;

    private void OnValidate()
    {
        nome = name;
    }
}
