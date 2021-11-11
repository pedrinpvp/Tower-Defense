using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ondas_Adm : MonoBehaviour
{
    public Mob_Obj inimigoPrefab;
    public List<Onda> ondas = new List<Onda>();
    public int turn = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CriarInimigosDaOnda());
    }

    IEnumerator CriarInimigosDaOnda()
    {
        int v = 0;
        foreach (var onda in ondas[turn].inimigosPorSaida)
        {
            while(v < onda.Mobs.Count)
            {
                foreach (var mob in onda.Mobs)
                {
                    var inimigoNovo = inimigoPrefab;
                    inimigoNovo.gameObject.name = mob.name;
                    inimigoNovo.Init(mob, onda.entrada);
                    Instantiate(inimigoNovo, onda.Saida.transform.position, onda.Saida.transform.rotation);
                    yield return new WaitForSeconds(onda.tempo);
                    v++;
                }
            }
            v = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
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
}

