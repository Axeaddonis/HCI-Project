using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player{
	public int playerNumber;	// The player's number in the turn order, for prototype can be 1 or 2
	public int health;			// Player's health
	public Card[] cards;		// An array of the player's cards that are in play
	public int numCards;		// Number of cards in play
	public int redMana;			// Amount of red mana in the player's mana pool to play or activate cards
	int blueMana;				// Amount of blue mana in the player's mana pool - not used
	int greenMana;				// Amount of green mana in the player's mana pool - not used
	int blackMana;				// Amount of black mana in the player's mana pool - not used
	int whiteMana;				// Amount of white mana in the player's mana pool - not used
	bool hasCards;				// Used to prevent issues with the card array

	// Constructor
	public Player(int playernum) 
	{
		playerNumber = playernum;
		health = 20;
		cards = new Card[20];
		numCards = 0;
		redMana = 0;
		blueMana = 0;
		greenMana = 0;
		whiteMana = 0;
		blackMana = 0;
		hasCards = false;
	}

	// Adds a card to the player's array of cards
	public void addCard(Card newcard)
	{
		cards[numCards] = newcard;
		numCards++;

		if (numCards == 1) {
			hasCards = true;
		}
	}

	// Removes a card from the player's array of cards - not used
	public void remCard(int cardNumber)
	{
		// Simply shift any cards after the removed card up one
		while (cardNumber != numCards)
		{
			cards[cardNumber]=cards[cardNumber + 1];
		}

		numCards--;

		if (numCards == 0) {
			hasCards = false;
		}
	}

	// Returns the player's card array as a string used in the UI
	public string getCardsString()
	{
		if (hasCards == true) {
			string cardString = "\n";

			for (int index = 0; index < numCards; index++) {
				cardString = string.Concat ( cardString, cards [index].CardName + "\n");
			}

			return cardString;
		} 

		else
			return "\n No Cards";
	}
}
