using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Torres_Adm : MonoBehaviour
{
    [SerializeField]
    private Grid grid;
    [SerializeField]
    private Tilemap torres = new Tilemap();
    [SerializeField]
    private Torre_Obj torreTest;
    [SerializeField]
    private Canvas canvasScreen;
    [SerializeField]
    private GameObject torresHolder;
    private Vector3Int previousMousePos = new Vector3Int();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RegisterClick();
    }

    private void RegisterClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3Int mousePos = GetMousePosition();
            if (!mousePos.Equals(previousMousePos))
            {
                Debug.Log(torres.GetTile(mousePos));
                //torres.SetTile(previousMousePos, null); // Remove old hoverTile
                //torres.SetTile(mousePos, hoverTile);
                if (torres.GetTile(mousePos) != null) ColocarTorre(grid.GetCellCenterWorld(mousePos));
                previousMousePos = mousePos;
            }
        }
    }

    private void ColocarTorre(Vector3 pos)
    {
        Vector3 newPos = new Vector3(pos.x, pos.y + 0.275f);
        Instantiate(torreTest, newPos, Quaternion.identity, torresHolder.transform);
    }

    private Vector3Int GetMousePosition()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return grid.WorldToCell(mouseWorldPos);
    }
}
