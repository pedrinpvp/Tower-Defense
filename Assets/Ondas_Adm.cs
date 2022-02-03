using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ondas_Adm : Singleton<Ondas_Adm>
{
    public Mob_Obj inimigoPrefab;
    public GameManager gameManager;
    public List<Onda> ondas = new List<Onda>();
    public Button chamarWave;
    public WaveControlUI waveControlUI;
    public int turno = 0;
    public float tempoAteProximaWave = 0f;
    public float maxTempoAteWave = 0f;
    public bool aguardando;
    public bool venceu;
    void Start()
    {
        //TODO: Remover aguardando e usar apenas o GameManager.State == GameState.WaitingForNextWave
        gameManager = GameManager.GetInstance();
        aguardando = true;
        chamarWave.onClick.AddListener(delegate { gameManager.UpdateGameState(GameState.StartWave); });
    }

    void Update()
    {
        if (!venceu)
        {
            //TODO: Check if the button is working without this.
            //chamarWave.gameObject.SetActive(aguardando);
        }
        if (aguardando && !venceu)
        {
            if (turno + 1 > ondas.Count)
                RegistrarVitória();
            if (turno != 0) ContagemAteProximaWave();
        }
    }

    private void OnValidate()
    {
        List<Onda> ondasTemp = new List<Onda>();
        ondasTemp.Clear();
        ondas.Clear();
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).name = "Onda" + (i+1);
            ondasTemp.Add(transform.GetChild(i).GetComponent<Onda>());
        }
        for (int i = 0; i < ondasTemp.Count; i++)
        {
            ondas.Add(ondasTemp[i]);
        }
    }

    IEnumerator CriarInimigosDaOnda()
    {
        int v = 0;
        foreach (var onda in ondas[turno].inimigosPorSaida)
        {
            while (v < onda.Mobs.Count)
            {
                foreach (var mob in onda.Mobs)
                {
                    var inimigoNovo = Instantiate(inimigoPrefab, onda.Saida.transform.position, onda.Saida.transform.rotation);
                    inimigoNovo.Init(mob, onda.entrada);
                    inimigoNovo.gameObject.name = mob.name;
                    inimigoNovo.InitializeCanva();
                    yield return new WaitForSeconds(onda.tempoMobs);
                    v++;
                }
            }
            v = 0;
        }
        maxTempoAteWave = ondas[turno].tempoProximaWave;
        aguardando = true;
        turno++;
        gameManager.UpdateGameState(GameState.WaitNextWave);
        if (waveControlUI)
        {
            waveControlUI.SayHi();
            waveControlUI.SetMinAndMaxValues(tempoAteProximaWave, maxTempoAteWave);
        }
    }

    public void ChamarProximaWave()
    {
        if (aguardando)
        {
            Debug.Log("Chamar wave " + turno);
            aguardando = false;
            StartCoroutine(CriarInimigosDaOnda());
        }
    }

    private void ContagemAteProximaWave()
    {
        tempoAteProximaWave += Time.deltaTime;
        if(tempoAteProximaWave >= maxTempoAteWave)
        {
            GameManager.GetInstance().UpdateGameState(GameState.StartWave);
            tempoAteProximaWave = 0;
            maxTempoAteWave = 0;
        }
        if (waveControlUI)
            waveControlUI.UpdateValue(tempoAteProximaWave);
    }

    private void RegistrarVitória()
    {
        gameManager.UpdateGameState(GameState.Victory);
        venceu = true;
    }
}

