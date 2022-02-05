using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bala", menuName = "Tower Defense/Bala", order = 2)]
public class Bala_Scr : ScriptableObject
{
    [SerializeField] public Enums.TipoDeMunicao tipoDeMunicao = Enums.TipoDeMunicao.Direto;
    [SerializeField] public Enums.TipoDeDano tipoDeDano = Enums.TipoDeDano.Fisico;
    [Header("Numero de balas lan�adas.")]
    public int numDeBalas = 1;
    [Header("Se habilitado, diferentes balas ir�o primeiro procurar inimigos adicionais.")]
    public bool multitarget = false;
    [Header("Caso a bala seja dano em �rea, definir aqui a �rea de efeito.")]
    public float AOE = 0.5f;
    public Sprite imagem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
