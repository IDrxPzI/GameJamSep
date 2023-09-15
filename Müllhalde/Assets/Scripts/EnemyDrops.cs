using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyDrops
{
    private itemsToDrop[] item;

    enum itemsToDrop
    {
        Trash,
        Trash1,
        Trash2,
        Trash3,
        ReoRecycle,
    }

    public void DropItems()
    {
        //On enemy death, drop items
        int amountToDrop = Random.Range(1, 5);

        itemsToDrop[] newitem = new itemsToDrop[amountToDrop];

        Debug.Log($"enemy has dropped: {amountToDrop} items");
        for (int i = 0; i < amountToDrop; i++)
        {
            itemsToDrop items = (itemsToDrop)Random.Range(0, 5);
            newitem[i] = items;

            Debug.LogWarning($"item to drop{newitem[i]}");
        }
    }
}