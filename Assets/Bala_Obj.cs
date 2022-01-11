using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Bala_Obj : MonoBehaviour
{
    public Bala_Scr _stats;
    public GameObject _target;
    public Vector3 staticLocation;
    public int _dano;
    public float _velocidade;

    private SpriteRenderer spriteRenderer;
    private Vector2 startPos;
    
    public void Init(Bala_Scr stats, Transform target, float velocidade, int dano)
    {
        _stats = stats;
        _target = target.gameObject;
        staticLocation = target.position;
        _velocidade = velocidade;
        _dano = dano;
    }
        // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = _stats.imagem;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (_target == null) Destroy(gameObject);

        if (_stats.tipoDeMunicao == Enums.TipoDeMunicao.Direto) ShootTarget();
        else if (_stats.tipoDeMunicao == Enums.TipoDeMunicao.Area) ShootArea();
    }

    void ShootTarget()
    {
        try
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _velocidade * Time.deltaTime);
            if (Vector3.Distance(transform.position, _target.transform.position) < 0.001f)
            {
                _target.GetComponent<Mob_Obj>().vida -= _dano;
                Destroy(gameObject);
            }
        }
        catch (MissingReferenceException)
        {
            Destroy(gameObject);
        } 
        
    }

    private void ShootArea()
    {
        transform.position = Vector3.MoveTowards(transform.position, staticLocation, _velocidade * Time.deltaTime);
        if (Vector3.Distance(transform.position, staticLocation) < 0.001f)
        {
            _target.GetComponent<Mob_Obj>().vida -= _dano;
            Destroy(gameObject);
        }
    }
}
