using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BuyTowerButton : Button
{
    public int index;
    public Torre towerToBuy;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(index + " " + towerToBuy.name);
        onClick.AddListener(BuyTower);
    }

    public void ShowAnim()
    {
        //TODO: DoTween
    }

    public void BuyTower()
    {
        print("BUY TOWER");
        if(CasteloStats.GetInstance().CanAfford(towerToBuy.stats.custo))
            TowerSelection.GetInstance().Select(towerToBuy);
    }
}
