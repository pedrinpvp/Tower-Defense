using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TorresAdm : MonoBehaviour
{
    [SerializeField]
    private Grid grid;
    [SerializeField]
    private Tilemap torres = new Tilemap();

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
                previousMousePos = mousePos;
            }
        }
    }

    private Vector3Int GetMousePosition()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return grid.WorldToCell(mouseWorldPos);
    }
}
