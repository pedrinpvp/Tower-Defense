using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceAnimation : MonoBehaviour
{
    public void ActivateResourceCollect()
    {
        gameObject.GetComponentInParent<Resource>()?.StartFollowing();
    }
}
