using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDestroyer : MonoBehaviour
{
    BoxCollider2D boxcol;
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Respawn")
        {
            Destroy(gameObject);
        }
    }
}
