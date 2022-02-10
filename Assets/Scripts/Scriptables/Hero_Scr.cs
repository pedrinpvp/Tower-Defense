using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Hero", menuName = "Tower Defense/Hero", order = 3)]
public class Hero_Scr : Char_Scr
{
    public int regenPS = 5;
}

//------------------------HERANÇA-------------------------
public class BananaSplitCompletoDiet : BananaSplitCompleto
{
    public void TirarAcucarDosIngredientes()
    {

    }
}

public class BananaSplitCompleto : BananaSplit
{
    public MM mM;
}


public class BananaSplit
{
    public Banana minhaBanana;
    public Sorvete meuSorvete;
    public Calda calda;
    public Chantily chantily;
    //Banana, Sorvete, Calda, Chuchu, Chantily
}

public class Banana 
{
    public int proteina = 4;
    public int fibra = 12;
    public int potassio = 80;

}

public class Sorvete
{
    public Leite meuLeite;
    public int açucar;
    //Leite, Açucar, Conservante, Corantes, Aromatizante
}

public class Leite
{

}
public class Calda
{

}
public class Chantily
{

}

public class MM
{

}


