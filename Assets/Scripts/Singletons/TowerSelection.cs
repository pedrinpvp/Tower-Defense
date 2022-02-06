using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSelection : Singleton<TowerSelection>
{
    [SerializeField]
    public Vector3 storedMousPos;
    [SerializeField]
    private BuyTowerButton buyTowerButton;
    [SerializeField]
    private List<BuyTowerButton> buttonsInScene = new List<BuyTowerButton>();
    [SerializeField]
    private List<Torre_Scr> torres = new List<Torre_Scr>();
    // Start is called before the first frame update
    void Start()
    {
        GenerateButonsForScene(Torres_Adm.GetInstance().GetTorresInventory());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void GenerateButonsForScene(List<Torre_Scr> torre_Scrs)
    {
        for (int i = 0; i < torre_Scrs.Count; i++)
        {
            buttonsInScene.Add(Instantiate(buyTowerButton, transform));
            torres.Add(torre_Scrs[i]);
            buttonsInScene[i].towerToBuy = torre_Scrs[i];
            buttonsInScene[i].index = i;
            buttonsInScene[i].button.onClick.AddListener(transform.parent.GetComponent<UIScreen>().CloseScreen);
            buttonsInScene[i].SetSprite(torre_Scrs[i].sprite);
        }
    }


    public void ShowSelection()
    {
        transform.position = storedMousPos;
    }

    public void HideSelection()
    {

    }

    public void Select(Torre_Scr torre_Scr)
    {
        Torres_Adm.GetInstance().ColocarTorre(storedMousPos, torre_Scr);
    }

    internal void StorePosition(Vector3 mousePos)
    {
        storedMousPos = mousePos;
    }
}