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
        if (!temp) { temp = new GameObject(); temp.name = "hero destination";}
        if (clicksManager.DoesCollideInLayerOnGrid(layer, layersToAvoid))
        {
            Debug.Log(~layer);
            Vector3 mouseWorldPos = clicksManager.GetMousePosition();
            temp.transform.position = mouseWorldPos;
            destinationSetter.target = temp.transform;
        }
        if (temp) FliparDeAcordoComTarget(temp.transform);
    }
}
