using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{

    private bool collided;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Bullet"  && !collided)
        {
            collided = true;
            Destroy(gameObject);
        }
    }

}
