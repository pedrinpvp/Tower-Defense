using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateResourceCollect()
    {
        gameObject.GetComponentInParent<Resource>()?.StartFollowing();
    }
}
