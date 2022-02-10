using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Torre : MonoBehaviour
{
    public Torre_Scr _stats;
    public Bala balaPrefab;
    [SerializeField] private Torre_Anim animLoader;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private CircleCollider2D colisorCirculo;
    public List<Transform> inimigos = new List<Transform>();
    public Transform inimigoMaisPerto;
    [SerializeField] private float alcance;
    public bool cooldown;

    void Start()
    {
        colisorCirculo = GetComponent<CircleCollider2D>();
        colisorCirculo.radius = alcance/2;
    }

    public void Init(Torre_Scr stats)
    {
        _stats = stats;
        spriteRenderer.sprite = _stats.sprite;
        Debug.LogWarning($"I'm {_stats.name} and my animator is {_stats.animatorOverride.name}");
        animLoader.Init(_stats.animatorOverride);
        alcance = _stats.alcance;
    }

    void Update()
    {
        if (inimigos.Any())
        {
            //if (inimigoMaisPerto != null) Debug.Log(gameObject.name + " " + inimigoMaisPerto.name);
            //foreach (var inimigo in inimigos)
            //{
            //    Debug.Log(gameObject.name + " " + inimigo.name);
            //}
            if (!inimigos.Contains(inimigoMaisPerto))
            {
                inimigoMaisPerto = EncontrarMaisPerto();
                if (inimigoMaisPerto != null)
                    StartCoroutine(AtirarNoInimigo());
            }
            if (inimigoMaisPerto != null)
            {
                animLoader.MoverComInimigo(inimigoMaisPerto);
            }
            else
            {
                animLoader.MudarEstado(Enums.AnimacoesBasicas.Idle);
            }
        }
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Mob>())
        {
            if (!inimigos.Contains(collision.transform))
            {
                inimigos.Add(collision.transform);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Mob>())
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

        try
        {
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
        catch (Exception)
        {
            return null;
            //throw;
        }
        
    }


    IEnumerator AtirarNoInimigo()
    {
        var inimigoAtual = inimigoMaisPerto;
        if (!cooldown)
        {
            Debug.Log("Atirar");
            animLoader.MudarEstado(Enums.AnimacoesBasicas.Shoot);
            var bala = Instantiate(balaPrefab, spriteRenderer.transform.position, spriteRenderer.transform.rotation);
            if (inimigoMaisPerto != null) bala.Init(_stats.bala, inimigoMaisPerto, _stats.velocidadeBala, _stats.dano);
            bala.gameObject.name = _stats.bala.name;
            cooldown = true;
            yield return new WaitForSeconds(1 / _stats.cadencia);
        }
        else
        {
            yield return new WaitForSeconds(1 / _stats.cadencia / 2);
        }
        cooldown = false;
        if (inimigoAtual == inimigoMaisPerto && inimigoMaisPerto != null) StartCoroutine(AtirarNoInimigo());
    }

    
    //float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    //{
    //    Vector2 direction = a - b;
    //    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    //    Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    //    return angle;
    //}

}
