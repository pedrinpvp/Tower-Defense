using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MostraVida : MonoBehaviour
{
    public int minimo = 0;
    public int maximo = 10;
    public Slider hpslider; 
    public TextMeshProUGUI hpTexto; 

    // Start is called before the first frame update
    void Start()
    {
        hpslider = GetComponent<Slider>();
        hpslider.value = hpslider.maxValue;

    }

    // Update is called once per frame
    void Update()
    {
        if (hpslider.value > 0)
        {
            hpTexto.text = hpslider.value.ToString();
        }
        else
        {
            hpTexto.text = "Morreu Otaro";
        }
        TestarComTeclado();
    }

    public void TestarComTeclado()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            hpslider.value --;
        }
    }

}
