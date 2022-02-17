using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using static Enums;

public class Hero : Character
{
    AIDestinationSetter destinationSetter;
    ClicksManager clicksManager;
    GameObject destination;
    [SerializeField] LayerMask layer;
    [SerializeField] LayerMask layersToAvoid;
    private Hero_Scr stats;
    [SerializeField]
    private float remainingDistance;

    #region Shooting

    private CircleCollider2D colisorCirculo;
    public List<Transform> inimigos = new List<Transform>();
    public Transform inimigoMaisPerto;
    [SerializeField] private float alcance;
    [SerializeField] private float cadencia;
    public bool cooldown;
    #endregion

    void Start()
    {
        Init(_stats);
        stats = _stats as Hero_Scr;
        layersToAvoid = ~layer;
        clicksManager = ClicksManager.GetInstance();
        destinationSetter = GetComponent<AIDestinationSetter>();
        alcance = stats.alcance;
        cadencia = stats.cadencia;
        colisorCirculo = GetComponent<CircleCollider2D>();
        colisorCirculo.radius = alcance / 2;
    }

    void Update()
    {
        #region Shooting
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
        }
        else
        {
            inimigoMaisPerto = null;
        }

        if (inimigoMaisPerto == null)
            anim.ChangeAnim(Enums.AnimacoesBasicas.Idle);
        #endregion

        #region Walking
        if (!clicksManager.Clicked()) return;
        if (!destination) 
        { 
            destination = new GameObject(); 
            destination.name = "hero destination"; 
            BoxCollider2D bc = destination.AddComponent<BoxCollider2D>(); 
            bc.isTrigger = true; 
            bc.size = new Vector2(.3f, .3f); 
        }
        if (clicksManager.DoesCollideInLayerOnGrid(layer, layersToAvoid))
        {
            Vector3 mouseWorldPos = clicksManager.GetMousePosition();
            destination.transform.position = mouseWorldPos;
            destinationSetter.target = destination.transform;
        }
        if (destination) FliparDeAcordoComTarget(destination.transform);

        remainingDistance = aiLerp.remainingDistance;
        #endregion

        LifeCheck();

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "hero destination")
        {
            anim.ChangeAnim(AnimacoesBasicas.Idle);
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
        if (collision.name == "hero destination")
        {
            anim.ChangeAnim(AnimacoesBasicas.Run);
        }
        else if (collision.gameObject.GetComponent<Mob>())
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
            anim.ChangeAnim(Enums.AnimacoesBasicas.Shoot);
            inimigoMaisPerto.GetComponent<Mob>().vida -= _stats.dano;
            cooldown = true;
            yield return new WaitForSeconds(1 / cadencia);
        }
        else
        {
            yield return new WaitForSeconds(1 / cadencia / 2);
        }
        cooldown = false;
        if (inimigoAtual == inimigoMaisPerto && inimigoMaisPerto != null) StartCoroutine(AtirarNoInimigo());
    }
}
