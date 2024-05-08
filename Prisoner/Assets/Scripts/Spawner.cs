using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject hazard;
    BoxCollider2D boxcol;
    public float speed = 5f;
    public float repeatTime = 1;
    public float firstTime = 1;

    void Start()
    {
        InvokeRepeating("Spawn", firstTime,repeatTime);
    }

    void Spawn()
    {
        Vector3 spawnLocation = transform.position;
        GameObject newHazard = Instantiate(hazard, spawnLocation, Quaternion.identity) as GameObject;
        newHazard.GetComponent<Rigidbody2D>().velocity = transform.right * speed;
    }

    
}
