using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform[] spawns;
    BulletsManager bulletsManager;

    public float speed;
    public float rate;
    
    private float shootTime = 0;

    private int teamNumber;

    public void Init(int team, BulletsManager bulletsManager)
    {
        this.teamNumber = team;
        this.bulletsManager = bulletsManager;
    }

    public void Fire(Plane plane)
    {
        if (shootTime >= rate)
        {
            shootTime = 0;
            GameObject rocketInstance;
            foreach (var spawn in spawns)
            {
                rocketInstance = bulletsManager.EnableBullet();
                if(rocketInstance != null)
                {
                    rocketInstance.SetActive(true);
                    rocketInstance.layer = LayerMask.NameToLayer("Bullets" + plane.teamNumber.ToString());
                    rocketInstance.gameObject.transform.position = new Vector3(spawn.position.x, spawn.position.y, 0.1f);
                    //rocketInstance.GetComponent<Rigidbody2D>().position = spawn.position;
                    rocketInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(spawn.up.x * speed, spawn.up.y * speed);
                }
            }
        }
        
    }

    private void FixedUpdate()
    {
        if (shootTime <= 1) shootTime += 0.1f;
    }
}
