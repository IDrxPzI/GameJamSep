using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyDrops
{
    private itemsToDrop[] item;
    public static int amountTrash = 0;
    public static int amountReoRecycle = 0;

    public int ReoPoints
    {
        get => amountReoRecycle;
        set => amountReoRecycle = value;
    }

    public int TrashPoints => amountTrash;

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

            if (items <= (itemsToDrop)3)
            {
                amountTrash++;
            }
            else
            {
                amountReoRecycle++;
            }

            Debug.LogWarning($"item to drop{newitem[i]}");
            Debug.Log($"you currently have {amountTrash} trash");
            Debug.Log($"you currently have {amountReoRecycle} reorecycle");

            //LevelManager.ReoRecyclePoints.SetText($"{amountReoRecycle[i]}");
        }
    }
}