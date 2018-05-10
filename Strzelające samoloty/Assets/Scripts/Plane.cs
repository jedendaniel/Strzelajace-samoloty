using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class PlaneDetails
{
    public string name;
    [Range(1,2)]
    public int teamNumber;

    public float forceScale = 6f;
    public float rotateScale = 5f;
    public float maxVelocity = 6f;
    public float shootRate = 0.3f;
    public float maxHealth = 100f;
    public float healDelay;
    public float healRate;
}

public class Plane : MonoBehaviour
{
    public PlaneDetails details;

    [SerializeField]
    private Image healthBar;
    [SerializeField]
    private Text nameText;
    [SerializeField]
    private Weapon weapon;
    [SerializeField]
    private Transform planeAnchor1;
    [SerializeField]
    private Transform planeAnchor2;
    [SerializeField]
    private Collider2D planeBottom;

    Rigidbody2D rb;

    float healthPoints;
    float baseTime;
    bool inBase = false;


    public Flag flag { get; set; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        healthPoints = details.maxHealth;
        nameText.text = details.name;
        weapon.Init(details.teamNumber);
    }

    private void Update()
    {
        if (inBase && healthPoints < details.maxHealth)
        {
            if (baseTime + details.healDelay <= Time.fixedTime)
            {
                RecoverHealth();
            }
        }
    }

    public void MoveForward()
    {
        if (rb.velocity.magnitude < details.maxVelocity || (rb.velocity.x >= 0 && transform.up.x <= 0) || (rb.velocity.x <= 0 && transform.up.x >= 0)
            || (rb.velocity.y >= 0 && transform.up.y <= 0) || (rb.velocity.y <= 0 && transform.up.y >= 0))
        {
            rb.AddForce(transform.up.normalized * details.forceScale);
        }
    }

    public void Rotate(float rotation)
    {

        rb.angularVelocity = 0;
        rb.rotation += rotation * details.rotateScale;
    }

    public void Shoot()
    {
        weapon.Fire(rb.velocity);            
    }

    public void RecoverHealth()
    {
        if(healthPoints + details.healRate < details.maxHealth)
        {
            healthBar.fillAmount += details.healRate / details.maxHealth;
            healthPoints += details.healRate;
        }
        else
        {
            healthBar.fillAmount = 1;
            healthPoints = details.maxHealth;
        }
    }

    public void GainDamage(float damage)
    {
        if (healthPoints > damage)
        {
            healthBar.fillAmount -= damage / details.maxHealth;
            healthPoints -= damage;
        }
        else
        {
            healthBar.fillAmount = 0;
            healthPoints = 0;
            GameObject go = GameObject.Find("GameManager");
            ((GameManager)go.GetComponent(typeof(GameManager))).EndGame(name);
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Bullet":
                Bullet bullet = collision.gameObject.GetComponent<Bullet>();
                GainDamage(bullet.power);
                Destroy(collision.gameObject);
                break;
            case "Base":
                baseTime = Time.fixedTime;
                inBase = true;
                Base planeBase = collision.gameObject.GetComponent<Base>();
                if (flag != null && planeBase.TeamNumber == details.teamNumber)
                {
                    if (flag.teamNumber == details.teamNumber)
                    {
                        flag.BackToStick();
                        flag = null;
                    }
                    else
                    {
                        GameObject go = GameObject.Find("GameManager");
                        ((GameManager)go.GetComponent(typeof(GameManager))).EndGame(details.name);
                    }
                }
                break;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Base":
                inBase = false;
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        switch (other.tag)
        {
            //case "Flag":
            //    if(flag == null)
            //    {
            //        Flag flag = other.transform.parent.GetComponent<Flag>();
            //        if (flag.teamNumber != this.details.teamNumber || (flag.teamNumber == this.details.teamNumber && !flag.inBase))
            //        {
            //            other.transform.parent.transform.Find("FlagAnchor1").GetComponent<DistanceJoint2D>().connectedBody = planeAnchor1.GetComponent<Rigidbody2D>();
            //            other.transform.parent.transform.Find("FlagAnchor2").GetComponent<DistanceJoint2D>().connectedBody = planeAnchor1.GetComponent<Rigidbody2D>();
            //            flag.transform.GetComponent<Rigidbody2D>().gravityScale = 0.3f;
            //            flag.transform.GetComponent<Rigidbody2D>().mass = 0.05f;
            //            if (flag.plane != null)
            //            {
            //                flag.plane.flag = null;
            //            }
            //            flag.plane = this;
            //            flag.inBase = false;
            //            this.flag = flag;
            //            flag.Link(planeAnchor1);
            //        }
            //    }
            //    break;
        }
    }
}
