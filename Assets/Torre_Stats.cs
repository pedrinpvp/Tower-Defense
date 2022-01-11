using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Torre_Stats : MonoBehaviour
{
    public Torre_Scr torre;
    public CircleCollider2D circle;
    public List<Transform> inimigos = new List<Transform>();
    public Transform inimigoMaisPerto;
    // Start is called before the first frame update
    void Start()
    {
        circle = gameObject.GetComponent<CircleCollider2D>();
        circle.radius = torre.alcance;
    }

    // Update is called once per frame
    void Update()
    {
        if (inimigos.Contains(inimigoMaisPerto) == false && inimigos.Any())
        {
            inimigoMaisPerto = EncontrarMaisPerto();
            Debug.Log(inimigoMaisPerto.gameObject.name);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Mob_Obj>())
        {
            if (inimigos.Contains(collision.transform) == false)
            {
                inimigos.Add(collision.transform);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Mob_Obj>())
        {
            if (inimigos.Contains(collision.transform))
            {
                inimigos.Remove(collision.transform);
            }
        }
    }
}
