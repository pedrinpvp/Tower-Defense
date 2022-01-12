using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_TowerSelection : UIScreen
{
    private Vector3 storedMousPos;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void StorePosition(Vector3 mousePos)
    {
        storedMousPos = mousePos;
    }

    public override void OpenScreen()
    {
        base.OpenScreen();
        screenToOpen.GetComponent<TowerSelection>().storedMousPos = storedMousPos;
        screenToOpen.GetComponent<TowerSelection>().ShowSelection();
    }
}
