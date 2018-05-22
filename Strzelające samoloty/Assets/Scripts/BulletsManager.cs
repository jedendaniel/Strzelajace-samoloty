using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsManager : MonoBehaviour {

    Bullet[] bullets;

	void Start () {
        bullets = GetComponentsInChildren<Bullet>();
        foreach(Bullet bullet in bullets)
        {
            bullet.gameObject.SetActive(false);
        }
	}
	
	void Update () {
		
	}

    public GameObject EnableBullet()
    {
        foreach(Bullet bullet in bullets)
        {
            if (!bullet.gameObject.activeInHierarchy) return bullet.gameObject;
        }
        return null;
    }
    
}
