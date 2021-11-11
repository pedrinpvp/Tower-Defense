using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enums : MonoBehaviour
{
    public enum Direcoes
    {
        cima,
        baixo,
        esquerda,
        direita
    }

    public enum TipoDeDano 
    {
        Fisico,
        Magico
    }
    public enum TipoDeMunicao
    {
        Area,
        Direto
    }
}
