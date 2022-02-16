using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reiniciador : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public TextMeshProUGUI textoMeshProBotao;
    //TODO: Mudar Reiniciar() para Continuar()
    public void Reiniciar()
    {
        SceneManager.LoadScene(1);
    }
    public void Continuar()
    {
        //N�o faz nada.
    }

    public void AvisarVitoria()
    {
        textMeshPro.text = "Voc� venceu.";
        textoMeshProBotao.text = "Continuar";
    }
    public void AvisarDerrota()
    {
        textMeshPro.text = "Voc� perdeu.";
        textoMeshProBotao.text = "Voltar";
    }
}
