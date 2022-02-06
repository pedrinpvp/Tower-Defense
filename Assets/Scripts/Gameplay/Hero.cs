using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Hero : Character
{
    AIDestinationSetter destinationSetter;
    ClicksManager clicksManager;
    GameObject temp;
    public Tilemap cenario, caminho;
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
        if (!temp) { temp = new GameObject(); temp.name = "hero destination"; BoxCollider2D bc = temp.AddComponent<BoxCollider2D>(); bc.isTrigger = true; bc.size = new Vector2(.3f, .3f); }
        if (clicksManager.DoesCollideInLayerOnGrid(layer, layersToAvoid))
        {
            Vector3 mouseWorldPos = clicksManager.GetMousePosition();
            temp.transform.position = mouseWorldPos;
            destinationSetter.target = temp.transform;
        }
        if (temp) FliparDeAcordoComTarget(temp.transform);
        //if (aiLerp.) anim.ChangeAnim(AnimacoesBasicas.Idle);
        //else if (aiLerp.remainingDistance > .5f)anim.ChangeAnim(AnimacoesBasicas.Run);
        
        remainingDistance = aiLerp.remainingDistance;
        LifeCheck();
    }
}
