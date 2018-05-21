using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform[] spawns;

    public float speed;
    public float rate;
    
    private float shootTime = 0;

    private int teamNumber;

    public void Init(int team)
    {
        this.teamNumber = team;
    }

    public void Fire(Plane plane)
    {
        if (shootTime >= rate)
        {
            shootTime = 0;
            GameObject rocketInstance;
            foreach (var spawn in spawns)
            {
                rocketInstance = GameObject.Instantiate(bulletPrefab, spawn.position, spawn.rotation) as GameObject;
                rocketInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(spawn.up.x * speed, spawn.up.y * speed);
                rocketInstance.transform.parent = this.transform;
                rocketInstance.layer = LayerMask.NameToLayer("Bullets" + plane.details.teamNumber.ToString());
            }
        }
        
    }

    private void FixedUpdate()
    {
        if (shootTime <= 1) shootTime += 0.1f;
    }
}
