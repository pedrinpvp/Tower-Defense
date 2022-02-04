using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Hero_Obj : Character
{
    AIDestinationSetter destinationSetter;
    ClicksManager clicksManager;
    GameObject temp;
    public Tilemap cenario, caminho;
    [SerializeField] LayerMask layer;
    // Start is called before the first frame update
    void Start()
    {
        clicksManager = ClicksManager.GetInstance();
        destinationSetter = GetComponent<AIDestinationSetter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!clicksManager.Clicked()) return;
        if (!temp) { temp = new GameObject(); temp.name = "hero destination"; temp.transform.parent = transform;}
        Vector3 mouseWorldPos = clicksManager.GetMousePosition();
        if (clicksManager.DoesCollideInLayer(layer))
        {
            Debug.Log($"goto {mouseWorldPos}");
            temp.transform.position = mouseWorldPos;
            destinationSetter.target = temp.transform;
        }
    }
}
