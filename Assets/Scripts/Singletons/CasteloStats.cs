using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CasteloStats : Singleton<CasteloStats>
{
    private VidaConfig vidaCastelo;
    private int _dinheiroAtual;
    public int dinheiroIni;

    [HideInInspector]
    public int dinheiroAtual { 
        get => _dinheiroAtual; 
        set { _dinheiroAtual = value; UpdateText(); } 
    }

    public TextMeshProUGUI dinheiroText; 
    // Start is called before the first frame update
    void Start()
    {
        vidaCastelo = GetComponent<VidaConfig>();
        dinheiroAtual = dinheiroIni;
    }

    // Update is called once per frame
    void Update()
    {
        if (vidaCastelo.vidaAtual <= 0)
        {
            if (GameManager.GetInstance().State != GameState.Victory)
                GameManager.GetInstance().UpdateGameState(GameState.Lose);
        }
    }

    public void UpdateText()
    {
        if (dinheiroText) dinheiroText.text = _dinheiroAtual.ToString();
    }

    public bool CanAfford(int cost)
    {
        if (dinheiroAtual - cost >= 0) 
        {
            dinheiroAtual -= cost;
            return true; 
        }
        return false;
    }

    public void AddSeeds(int amount)
    {
        dinheiroAtual += amount;
    }
}
