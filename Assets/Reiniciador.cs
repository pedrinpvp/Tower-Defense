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
        //Não faz nada.
    }

    public void AvisarVitoria()
    {
        textMeshPro.text = "Você venceu.";
        textoMeshProBotao.text = "Continuar";
    }
    public void AvisarDerrota()
    {
        textMeshPro.text = "Você perdeu.";
        textoMeshProBotao.text = "Voltar";
    }
}
