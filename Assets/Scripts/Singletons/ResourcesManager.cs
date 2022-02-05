using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GoToFinalPointEvent : UnityEvent<FinalPointResources> { }

public class MobDestroyed : UnityEvent<int, Vector3> { }

public class ResourcesManager : Singleton<ResourcesManager>
{
    [SerializeField]
    private LayerMask layer;
    private ClicksManager clicksManager;
    public GoToFinalPointEvent clickedResource;
    public FinalPointResources finalPoint;
    public MobDestroyed mobDestroyed;
    [Header("Ordered from biggest to smallest")]
    public List<Resource_Scr> resources_Stats = new List<Resource_Scr>();
    public Resource resourceObj;
    private void Awake()
    {
        if (clickedResource == null) clickedResource = new GoToFinalPointEvent();
        if (mobDestroyed == null) mobDestroyed = new MobDestroyed();
        mobDestroyed.AddListener(SpawnResources);
        clicksManager = ClicksManager.GetInstance();
        if (clicksManager == null) clicksManager = FindObjectOfType<ClicksManager>().GetComponent<ClicksManager>(); 
    }

    private void Start()
    {
        
    }
    private void Update()
    {
        if (clicksManager.DoesCollideInLayer(layer, out GameObject resource))
        {
            resource.GetComponent<Resource>().ActivateFollow(finalPoint);
            clickedResource.Invoke(finalPoint);
        }
    }

    private void SpawnResources(int amount, Vector3 spawnPos)
    {
        //TODO: REMOVE HARDCODED COUNT VAR TO PREVENT CRASH
        List<Resource_Scr> resourcesToSpawn = new List<Resource_Scr>();
        int count = 0;
        bool added = false;
        while(amount != 0 && count <= 20) 
        {
            foreach (var item in resources_Stats)
            {
                if (!added)
                {
                    if (amount >= item.amount)
                    {
                        resourcesToSpawn.Add(item);
                        amount -= item.amount;
                        count++;
                        added = true;
                    }
                }
            }
            added = false;
        }
        string output = "";
        foreach (var item in resourcesToSpawn)
        {
            output += " " + item.name;
            var resource = Instantiate(resourceObj, spawnPos, Quaternion.identity, transform);
            resource.Init(item);
        }
        Debug.Log(output);
    }
}
