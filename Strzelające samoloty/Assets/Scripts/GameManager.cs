using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Text endGameMessage;

    [SerializeField]
    private Player[] players;
    [SerializeField]

    private void Awake()
    {
        
    }

    void Start () {
        for (int i = 0; i < players.Length; i++)
        {
            players[i].Init();
        }
    }
	
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
    }
}
