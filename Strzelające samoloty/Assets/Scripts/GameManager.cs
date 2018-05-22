using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Text endGameMessage;
    public List<Plane> planes;

    private void Awake()
    {
        
    }

    void Start () {

    }
	
	void Update () {
        if(planes.Count == 1)
        {
            Time.timeScale = 0;
            endGameMessage.text = planes[0].playerName + " wins!";
        }
    }

    private void FixedUpdate()
    {
    }

    public void WinGame(Plane plane)
    {
        Time.timeScale = 0;
        endGameMessage.text = plane.playerName + " wins!";
    }

    public void EndGame(Plane plane)
    {
        if (planes.Contains(plane))
        {
            planes.Remove(plane);
        }
    }
}
