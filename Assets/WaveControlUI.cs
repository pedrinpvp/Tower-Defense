using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaveControlUI : SingletonInstance<WaveControlUI>
{
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private Button UIButton;
    [SerializeField]
    private TextMeshProUGUI waveControlText;
    // Start is called before the first frame update
    void Awake()
    {
        GameManager.OnGameStateChanged += UpdateWaveText;
    }

    //private void OnDestroy()
    //{
    //    GameManager.OnGameStateChanged -= UpdateWaveText;
    //}

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMinAndMaxValues(float min, float max)
    {
        Debug.LogWarning("SET MIN AND MAX");
        slider.maxValue = max;
        slider.minValue = min;
    }

    public void UpdateValue(float val)
    {
        Debug.LogWarning("UPDATE VALIE");
        slider.value = val;
    }

    private void UpdateWaveText(GameState state)
    {
        Debug.LogWarning("UPDATED " + state.ToString());
        if (state == GameState.WaitStartInput || state == GameState.WaitNextWave)
        {
            UIButton.gameObject.SetActive(true);
            UIButton.interactable = true;
        }
        else
        {
            UIButton.interactable = false;
            slider.value = 0;
        }
        //else
        //{
        //    UIButton.gameObject.SetActive(false);
        //}
        if (state == GameState.WaitStartInput)
            waveControlText.text = "START";
        else if (state == GameState.StartWave)
            waveControlText.text = $"Onda {Ondas_Adm.GetInstance().turno + 1}";
    }

    internal void SayHi()
    {
        Debug.LogWarning("HI!");
    }
}
