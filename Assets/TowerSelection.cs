using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSelection : SingletonInstance<TowerSelection>
{
    [SerializeField]
    public Vector3 storedMousPos;
    [SerializeField]
    private BuyTowerButton buyTowerButton;
    [SerializeField]
    private List<BuyTowerButton> buttonsInScene = new List<BuyTowerButton>();
    private List<Torre_Obj> torres = new List<Torre_Obj>();
    // Start is called before the first frame update
    void Start()
    {
        GenerateButonsForScene(Torres_Adm.GetInstance().GetTorresInventory());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void GenerateButonsForScene(List<Torre_Obj> torre_Objs)
    {
        for (int i = 0; i < torre_Objs.Count; i++)
        {
            buttonsInScene.Add(Instantiate(buyTowerButton, transform));
            torres.Add(torre_Objs[i]);
            buttonsInScene[i].towerToBuy = torre_Objs[i];
            buttonsInScene[i].index = i;
            buttonsInScene[i].onClick.AddListener(transform.parent.GetComponent<UIScreen>().CloseScreen);
        }
    }


    public void ShowSelection()
    {
        transform.position = storedMousPos;
    }

    public void HideSelection()
    {

    }

    public void Select(Torre_Obj torre_Obj)
    {
        Torres_Adm.GetInstance().ColocarTorre(storedMousPos, torre_Obj);
    }

    internal void StorePosition(Vector3 mousePos)
    {
        storedMousPos = mousePos;
    }
}