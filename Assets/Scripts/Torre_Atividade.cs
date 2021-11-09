using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torre_Atividade : MonoBehaviour
{
    public Torre_Scr stats;
    private Torre_Anima animLoader;
    private CircleCollider2D colisorCirculo;
    public List<Transform> inimigos = new List<Transform>();
    public Transform inimigoMaisPerto;
    [SerializeField] private float alcance;
    void Start()
    {
        colisorCirculo = GetComponent<CircleCollider2D>();
        animLoader = GetComponent<Torre_Anima>();
        colisorCirculo.radius = alcance/2;
    }

    void Update()
    {
        if (!inimigos.Contains(inimigoMaisPerto))
        {
            inimigoMaisPerto = EncontrarMaisPerto();
        }
        if (inimigoMaisPerto != null) MoverComInimigo();
    }


    private void OnValidate()
    {
        DefinirAlcance();
    }
    private void DefinirAlcance()
    {
        alcance = stats.alcance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Inimigo>())
        {
            if (!inimigos.Contains(collision.transform))
            {
                inimigos.Add(collision.transform);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Inimigo>())
        {
            if (inimigos.Contains(collision.transform))
            {
                inimigos.Remove(collision.transform);
            }
        }
    }
    Transform EncontrarMaisPerto()
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (Transform potentialTarget in inimigos)
        {
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }

        return bestTarget;
    }

    private void MoverComInimigo()
    {
        //Get the Screen positions of the object
        Vector2 positionOnScreen = transform.position;

        //Get the Screen position of the mouse
        Vector2 inimigoOnScreen = inimigoMaisPerto.position;

        //Get the angle between the points
        float angle = relative(inimigoOnScreen);

        //Ta Daaa
        SelecionarAnimacaoPorAngulo(angle);
        //transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }

    private void SelecionarAnimacaoPorAngulo(float angle)
    {
        if (angle > 0)
        {
            if (angle < 30)
            {
                animLoader.MudarAnimacao(Enums.Direcoes.direita);
            }
            else if (angle < 120 && angle > 60)
            {
                animLoader.MudarAnimacao(Enums.Direcoes.cima);
            }
            else if (angle > 150)
            {
                animLoader.MudarAnimacao(Enums.Direcoes.esquerda);
            }
        }
        else if (angle < 0)
        {
            if (angle > -30)
            {
                animLoader.MudarAnimacao(Enums.Direcoes.direita);
            }
            else if (angle > -120 && angle < -60)
            {
                animLoader.MudarAnimacao(Enums.Direcoes.baixo);
            }
            else if (angle < -150)
            {
                animLoader.MudarAnimacao(Enums.Direcoes.esquerda);
            }
        }
    }

    float relative(Vector2 target)
    {
        Vector3 relative = transform.InverseTransformPoint(target);
        return Mathf.Atan2(relative.y, relative.x) * Mathf.Rad2Deg;
        
    }
    //float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    //{
    //    Vector2 direction = a - b;
    //    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    //    Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    //    return angle;
    //}

}
