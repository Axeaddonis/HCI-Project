using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	// Use this for initialization
	public int playerNumber;
	public int health;
	public List<Card> cards;

	// Update is called once per frame
	public Player(int playernum) 
	{
		playerNumber = playernum;
		health = 20;
		cards = new List<Card> ();
	}
}
