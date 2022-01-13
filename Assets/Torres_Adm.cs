using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public class Torres_Adm : SingletonInstance<Torres_Adm>
{
    [SerializeField]
    private Grid grid;
    [SerializeField]
    private Tilemap torresTileMap = new Tilemap();
    [SerializeField]
    private List<Torre_Obj> inventarioDeTorres = new List<Torre_Obj>();
    [SerializeField]
    private GameObject torresHolder;
    private Vector3Int previousMousePos = new Vector3Int();
    [SerializeField]
    private UI_TowerSelection towerSelection;
    [SerializeField]
    private LayerMask layer;
    //Mouse Collision
    
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
                //No towers there yet
                if (!DoesThisCollide(grid.GetCellCenterWorld(mousePos)))
                {
                    //Has a space in towers grid
                    if (torresTileMap.GetTile(mousePos) != null)
                    {
                        towerSelection.StorePosition(grid.GetCellCenterWorld(mousePos));
                        towerSelection.OpenScreen();
                    }
                }
                //There is already a tower there
                else
                {
                    //TODO: Show tower upgrades, sell, etc.
                }
                previousMousePos = mousePos;
            }
        }
    }

    public void ColocarTorre(Vector3 pos, Torre_Obj torre)
    {
        Vector3 newPos = new Vector3(pos.x, pos.y + 0.275f);
        Instantiate(torre, newPos, Quaternion.identity, torresHolder.transform);
    }

    private Vector3Int GetMousePosition()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return grid.WorldToCell(mouseWorldPos);
    }

    private bool DoesThisCollide(Vector3 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100, layer);
        // Does the ray intersect any objects excluding the player layer
        if (hit.collider)
        {
            //Debug.Log($"COLLIDE {hit.collider} on layer {layer}, except {~layer}, direction {direction}");
            //Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
            return true;
        }

        return false;
    }

    public List<Torre_Obj> GetTorresInventory()
    {
        return inventarioDeTorres;
    }
}
