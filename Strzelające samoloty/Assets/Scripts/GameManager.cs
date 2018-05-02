using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Text endGameMessage;
    //public Plane plane1;
    //public Plane plane2;

    [SerializeField]
    private Player[] players;
    [SerializeField]

    private void Awake()
    {
        
    }

    // Use this for initialization
    void Start () {
        for (int i = 0; i < players.Length; i++)
        {
            players[i].Init();
        }
    }
	
	// Update is called once per frame
	void Update () {
        foreach (var player in players)
        {
            player.HandleInput();
        }
    }

    private void FixedUpdate()
    {
    }

    public void EndGame(string loser)
    {
        //if (plane1.name.Equals(loser))
        //{
        //    endGameMessage.text = plane2.details.name + " wins!!";
        //}
        //else
        //{
        //    endGameMessage.text = plane1.details.name + " wins!!";
        //}
        //Time.timeScale = 0;
    }
}
