using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ClicksManager : Singleton<ClicksManager>
{
    [SerializeField]
    private Grid grid;
    private Vector3Int previousMousePos = new Vector3Int();

    public Vector3Int RegisterUniqueClickOnGrid(LayerMask layer, out bool valid)
    {
        if (!Input.GetMouseButtonDown(0)) { valid = false; return Vector3Int.zero; }

        Vector3Int mousePos = GetMousePositionOnGrid();
        if (mousePos.Equals(previousMousePos)) { valid = false; return Vector3Int.zero; }

        previousMousePos = mousePos;
        valid = true;
        return mousePos;

    }

    public bool Clicked()
    {
        if (!Input.GetMouseButtonDown(0)) return false;
        return true;    
    }

    private Vector3Int GetMousePositionOnGrid()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return grid.WorldToCell(mouseWorldPos);
    }

    public Vector3 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public bool DoesCollideInLayer(LayerMask layer, out GameObject obj)
    {
        if (!Clicked()) { obj = null; return false; }
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100, layer);
        // Does the ray intersect any objects excluding the player layer
        if (hit.collider)
        {
            obj = hit.collider.gameObject;
            return true;
        }
        obj = null;
        return false;
    }
    public bool DoesCollideInLayer(LayerMask layer)
    {
        if (!Clicked()) return false;
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100, layer);
        // Does the ray intersect any objects excluding the player layer
        if (hit.collider) return true;
        return false;
    }
}
