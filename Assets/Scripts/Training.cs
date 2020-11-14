using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Training : MonoBehaviour
{
    public float health = 9999999f;

    public void TakeDamage(float amount)
    {
        health -= amount;
    }
}
