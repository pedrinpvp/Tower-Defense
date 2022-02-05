using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VidaMedidor : MonoBehaviour
{
    public VidaConfig vidaConfig;
    public Slider vidaSlider;
    public TextMeshProUGUI vidaText;
    public bool configurado;
    public bool autoInitialize;
    public GameObject follow;
    public int retries = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (autoInitialize) StartCoroutine(Init());
    }

    public void Initialize()
    {
        if (vidaConfig != null)
        {
            vidaSlider.maxValue = vidaConfig.vidaMax;
            vidaSlider.minValue = 0;
            configurado = true;
        }
    }
    private IEnumerator Init()
    {
        if (retries <= 2)
        {
            if (vidaConfig != null)
            {
                vidaSlider.maxValue = vidaConfig.vidaMax;
                vidaSlider.minValue = 0;
                configurado = true;
            }
            else
            {
                retries++;
                yield return new WaitForSeconds(2);
                StartCoroutine(Init());
            }
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        if (configurado)
        {
            vidaSlider.value = vidaConfig.vidaAtual;
            if (vidaText != null) vidaText.text = $"{vidaConfig.vidaAtual}/{vidaConfig.vidaMax}";
        }
        if (follow != null)
        {
            Vector2 newEnemyTransform = new Vector2(follow.transform.position.x, follow.transform.position.y + .5f);
            vidaSlider.gameObject.GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(newEnemyTransform);
        }
    }
}
