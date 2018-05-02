using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float power;
    
	void Start () {
        this.GetComponent<Bullet>().enabled = false;
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
