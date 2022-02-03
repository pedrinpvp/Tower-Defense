using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GoToFinalPointEvent: UnityEvent<FinalPointResources>
{

}
public class ResourcesManager : Singleton<ResourcesManager>
{
    [SerializeField]
    private LayerMask layer;
    private ClicksManager clicksManager;
    public GoToFinalPointEvent clickedResource;
    public FinalPointResources finalPoint;
    private void Awake()
    {
        if (clickedResource == null) clickedResource = new GoToFinalPointEvent();
        clicksManager = ClicksManager.GetInstance();
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
}
