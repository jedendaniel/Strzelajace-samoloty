using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour {

    //public Joint2D joint;
    public LineRenderer line;
    public Transform flagAnchor1;
    public Transform flagAnchor2;
    public Plane plane;
    Vector3 basePosition;

    Transform anchorPoint;

    public int teamNumber;
    bool linked = false;

    public bool inBase = true;

    // Use this for initialization
    void Start () {
        //PolygonCollider2D collider = GetComponentInChildren<PolygonCollider2D>();
        //line1.SetPosition(0, collider.points[1]);
        //line1.SetPosition(2, collider.points[2]);
        linked = false;
        inBase = true;
        basePosition = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (linked)
        {
            line.SetPosition(0, flagAnchor1.position);
            line.SetPosition(1, anchorPoint.position);
            line.SetPosition(2, flagAnchor2.position);
        }
    }

    public void BackToStick()
    {
        transform.position = basePosition;
        transform.rotation = new Quaternion(0, 0, 0, 0);
        transform.Find("FlagAnchor1").GetComponent<DistanceJoint2D>().connectedBody = null;
        transform.Find("FlagAnchor2").GetComponent<DistanceJoint2D>().connectedBody = null;
        transform.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
        transform.GetComponent<Rigidbody2D>().mass = 0.0f;
        transform.rotation = new Quaternion(0, 0, 1, -1f);
        inBase = true;
    }

    public void Link(Transform point)
    {
        anchorPoint = point;
        linked = true;
    }

    public void Unlink()
    {
        linked = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Rigidbody2D rb = joint.GetComponent<Rigidbody2D>();
        //rb = collision.GetComponent<Rigidbody2D>();
        switch (collision.tag)
        {
            case "Plane":
                //joint.connectedBody = collision.GetComponent<Rigidbody2D>();
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Plane":
                Plane p = other.GetComponent<Plane>();
                if (p.flag == null)
                {
                    if (teamNumber != plane.details.teamNumber || (teamNumber == plane.details.teamNumber && !inBase))
                    {
                        transform.Find("FlagAnchor1").GetComponent<DistanceJoint2D>().connectedBody = other.transform.Find("PlaneAnchor1").GetComponent<Rigidbody2D>();
                        transform.Find("FlagAnchor2").GetComponent<DistanceJoint2D>().connectedBody = other.transform.Find("PlaneAnchor1").GetComponent<Rigidbody2D>();
                        GetComponent<Rigidbody2D>().gravityScale = 0.3f;
                        GetComponent<Rigidbody2D>().mass = 0.05f;
                        if (plane != null)
                        {
                            plane.flag = null;
                        }
                        plane = p;
                        inBase = false;
                        plane.flag = this;
                        Link(other.transform.parent.transform.Find("PlaneAnchor1"));
                    }
                }
                break;
        }
    }
}
