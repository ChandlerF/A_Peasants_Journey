using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "New Defualt Object", menuName = "Inventory System/Items/Default")]
public class DefaultObject : ItemObject
{

    public void Awake()
    {
        type = ItemType.Default;
    }

}
