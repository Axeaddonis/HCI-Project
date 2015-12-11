using UnityEngine;
using System.Collections;

// Abstract card class
public abstract class Card
{
	public string CardColor;		// Indicates the color of a card - may be red, green, blue, white, black, or colorless
	public string CardName;			// Card Name
	public string CardType;			// Card Type - Land, Sorcery, Instant, Creature, Artifact, Enchantment
	public string CardSubType;		// Card Sub Type - This is used largely for effects, examples may include Goblin or Knight
	public int TotalCost;			// Total cost to put the card in play
	public int RedCost;				// Red mana needed to put the card in play
	public int BlueCost;			// Blue mana needed - not used in prototype
	public int GreenCost;			// Green mana needed - not used in prototype
	public int WhiteCost;			// White mana needed - not used in prototype
	public int BlackCost;			// Black mana needed - not used in prototype
	public int ColorlessCost;		// Mana of any color needed to put the card in play
	public bool tapped;				// Indicates whether the card has been used in a turn (in which case it usually cannot be used again)
									// Tapped is accessed but not ever changed for any functionality
	public GameManager gameManager;	// Access to the game manager

	public abstract void effect1();	// All cards have at least one effect - this implements that effect
	public abstract void play();	// Puts cards in play

}
