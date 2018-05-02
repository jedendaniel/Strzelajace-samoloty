using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour {

    [SerializeField]
    public int TeamNumber;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        //switch (collision.gameObject.tag)
        //{
        //    case "Bullet":
        //        Destroy(collision.gameObject);
        //        break;
        //    case "Plane":
        //        Plane plane = collision.gameObject.GetComponentInParent<Plane>();
        //        if (flag != null && planeBase.teamNumber == details.teamNumber)
        //        {
        //            if (flag.teamNumber == details.teamNumber)
        //            {
        //                flag.backToStick();
        //                planes.Add();
        //            }
        //            else
        //            {
        //                GameObject go = GameObject.Find("GameManager");
        //                ((GameManager)go.GetComponent(typeof(GameManager))).endGame(details.name);
        //            }
        //        }
        //        break;
        //}
    }


}

