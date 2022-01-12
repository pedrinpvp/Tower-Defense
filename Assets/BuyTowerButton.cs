using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyTowerButton : Button
{
    public int index;
    public Torre_Obj towerToBuy;
    // Start is called before the first frame update
    void Start()
    {
        onClick.AddListener(BuyTower);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuyTower()
    {
        TowerSelection.GetInstance().Select(towerToBuy);
    }
}
