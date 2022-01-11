using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ondas_Adm : MonoBehaviour
{
    public Mob_Obj inimigoPrefab;
    public List<Onda> ondas = new List<Onda>();
    public Button chamarWave;
    public int turno = 0;
    public bool aguardando;
    public bool venceu;
    void Start()
    {
        StartCoroutine(CriarInimigosDaOnda());
        chamarWave.onClick.AddListener(ChamarProximaWave);
    }

    void Update()
    {
        if (aguardando && !venceu)
        {
            if (turno + 1 >= ondas.Count)
                PassarDeFase();
        }
        if (!venceu) chamarWave.gameObject.SetActive(aguardando);
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
                    yield return new WaitForSeconds(onda.tempo);
                    v++;
                }
            }
            v = 0;
        }
        aguardando = true;
    }
    private void ChamarProximaWave()
    {
        if (aguardando)
        {
            Debug.Log("CHAMAR WAVE");
            turno++;
            aguardando = false;
            StartCoroutine(CriarInimigosDaOnda());
        }
    }
    private void PassarDeFase()
    {
        Debug.Log("VOCE VENCEU!");
        venceu = true;
    }
}

