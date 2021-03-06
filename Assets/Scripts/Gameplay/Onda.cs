using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Onda : MonoBehaviour
{
    public List<InimigosPorSaida> inimigosPorSaida;
    public float tempoProximaWave;
    public Onda()
    {
        inimigosPorSaida = new List<InimigosPorSaida>();
    }
}

[System.Serializable]
public class InimigosPorSaida
{
    public Saida Saida;
    public List<Mob_Scr> Mobs;
    public float tempoMobs;
    public int entrada;
    public InimigosPorSaida()
    {
        Saida = new Saida();
        Mobs = new List<Mob_Scr>();
    }
}


