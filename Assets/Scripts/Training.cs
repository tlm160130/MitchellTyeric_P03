using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Training : MonoBehaviour
{
    public float health = 9999999f;


    void Update()
    {
        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                TakeDamage(10f);
            }
        }
    }


    public void TakeDamage(float amount)
    {
        health -= amount;
    }
}
