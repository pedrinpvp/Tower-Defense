using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Resource", menuName = "Tower Defense/Resource", order = 3)]
public class Resource_Scr : ScriptableObject
{
    public int amount;
    public Sprite sprite;
}
