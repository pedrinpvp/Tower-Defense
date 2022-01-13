using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BuyTowerButton : Button
{
    public int index;
    public Torre_Obj towerToBuy;
    // Start is called before the first frame update
    void Start()
    {
        onClick.AddListener(BuyTower);
    }

    public void ShowAnim()
    {
        //TODO: DoTween
    }

    public void BuyTower()
    {
        if(CasteloStats.GetInstance().CanAfford(towerToBuy.stats.custo))
            TowerSelection.GetInstance().Select(towerToBuy);
    }
}
