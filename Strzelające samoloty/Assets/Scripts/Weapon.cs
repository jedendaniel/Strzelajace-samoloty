using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform[] spawns;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float rate;

    private float shootTime = 0;

    private int teamNumber;

    public void Init(int team)
    {
        this.teamNumber = team;
    }

    public void Fire(Vector2 planeVelocity)
    {
        if (shootTime >= rate)
        {
            shootTime = 0;
            GameObject rocketInstance;
            foreach (var spawn in spawns)
            {
                rocketInstance = GameObject.Instantiate(bulletPrefab, spawn.position, spawn.rotation) as GameObject;
                rocketInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(planeVelocity.x + spawn.up.x * speed, planeVelocity.y + spawn.up.y * speed);
                rocketInstance.transform.parent = this.transform;
                if (teamNumber == 1)
                    rocketInstance.layer = 13;
                else
                    rocketInstance.layer = 14;
            }
        }
        
    }

    private void FixedUpdate()
    {
        if (shootTime <= 1) shootTime += 0.1f;
    }
}
