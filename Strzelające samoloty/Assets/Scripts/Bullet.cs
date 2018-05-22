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
        gameObject.transform.position = new Vector3(0, 0, -200);
        gameObject.SetActive(false);
    }
}
