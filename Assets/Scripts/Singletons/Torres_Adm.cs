using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public class Torres_Adm : Singleton<Torres_Adm>
{
    [SerializeField]
    private Grid grid;
    [SerializeField]
    private Tilemap torresTileMap = new Tilemap();
    [SerializeField]
    private List<Torre_Scr> inventarioDeTorres = new List<Torre_Scr>();
    [SerializeField]
    private Torre torreObj;
    [SerializeField]
    private GameObject torresHolder;
    private Vector3Int previousMousePos = new Vector3Int();
    [SerializeField]
    private UI_TowerSelection towerSelection;
    [SerializeField]
    private LayerMask layer;

    private ClicksManager clicksManager;

    private void Start()
    {
        clicksManager = ClicksManager.GetInstance();
    }
    void Update()
    {
        CheckTowerClick();
    }

    private void CheckTowerClick()
    {
        var mousePos = clicksManager.RegisterUniqueClickOnGrid(layer, out bool valid);
        if (!valid) return;

        //No towers there yet
        if (!clicksManager.DoesCollideInLayer(layer))
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

    public void ColocarTorre(Vector3 pos, Torre_Scr torre_Scr)
    {
        Vector3 newPos = new Vector3(pos.x, pos.y);
        var newTower = Instantiate(torreObj, newPos, Quaternion.identity, torresHolder.transform);
        newTower.Init(torre_Scr);
    }

    

    public List<Torre_Scr> GetTorresInventory()
    {
        return inventarioDeTorres;
    }
}
