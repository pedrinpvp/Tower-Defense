using Pathfinding;
using System.Collections;
using System.Collections.Generic;
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
    // Start is called before the first frame update
    void Start()
    {
        Init(_stats);
        stats = _stats as Hero_Scr;
        layersToAvoid = ~layer;
        clicksManager = ClicksManager.GetInstance();
        destinationSetter = GetComponent<AIDestinationSetter>();
    }

    // Update is called once per frame
    void Update()
    {
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
        LifeCheck();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "hero destination")
        {
            anim.ChangeAnim(AnimacoesBasicas.Idle);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "hero destination")
        {
            anim.ChangeAnim(AnimacoesBasicas.Run);
        }
    }
}
