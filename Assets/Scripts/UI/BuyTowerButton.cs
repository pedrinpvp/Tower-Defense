using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BuyTowerButton : MonoBehaviour
{
    public int index;
    public Torre_Scr towerToBuy;
    public Button button;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(BuyTower);
    }

    public void SetSprite(Sprite sprite)
    {
        image.sprite = sprite;
    }

    public void ShowAnim()
    {
        //TODO: DoTween
    }

    public void BuyTower()
    {
        print("BUY TOWER");
        if(CasteloStats.GetInstance().CanAfford(towerToBuy.custo))
            TowerSelection.GetInstance().Select(towerToBuy);
    }
}
