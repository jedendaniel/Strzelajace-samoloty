using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour {
    
    public LineRenderer line;
    public Transform flagAnchor1;
    public Transform flagAnchor2;
    public Plane plane;
    Vector3 basePosition;
    public Transform StickAnchor;

    Transform anchorPoint;

    public int teamNumber;
    bool linked = false;

    public bool inBase = true;
    
    void Start () {
        linked = false;
        inBase = true;
        basePosition = transform.position;
    }
	
	void Update () {
        if (linked)
        {
            UpdateLine();
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
        Unlink();
    }

    void UpdateLine()
    {
        line.SetPosition(0, flagAnchor1.position);
        line.SetPosition(1, anchorPoint.position);
        line.SetPosition(2, flagAnchor2.position);
    }

    public void Link(Transform point)
    {
        anchorPoint = point;
        linked = true;
    }

    public void Unlink()
    {
        anchorPoint = StickAnchor;
        linked = false;
        UpdateLine();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Plane":
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
                    if (teamNumber != p.details.teamNumber || (teamNumber == p.details.teamNumber && !inBase))
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
                        Link(p.transform.Find("PlaneAnchor1"));
                    }
                }
                break;
        }
    }
}
