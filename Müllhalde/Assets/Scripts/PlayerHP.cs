using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    private int HP = 100;

    public void TakeDamage(int amount)
    {
        HP -= amount;
    }
}