using UnityEngine;
using System.Collections;

public class lava_axe : Card {
	
	public lava_axe(GameManager manager)
	{	
		CardColor = "Red";
		CardName = "Lava Axe";
		CardType = "Sorcery";
		CardSubType = "none";
		TotalCost = 5;
		RedCost = 1;
		BlueCost = 0;
		GreenCost = 0;
		WhiteCost = 0;
		BlackCost = 0;
		ColorlessCost = 4;
		tapped = true;
		gameManager = manager;
	}

	// The lava axe's effect is doing 5 damage to a target player, since the prototype has only two players,
	// and it is assumed the player would not target himself, the opposite player takes 5 damage
	// In the real game, this would provoke an opportunity for other players to activate certain effects or instants
	public override void effect1()
	{
		int currentPlayerNumber = gameManager.PlayerTurn;

		// Deal 5 damage to the target player
		if (currentPlayerNumber == 1) 
		{
			gameManager.player2.health -= 5;
			if (gameManager.player2.health <= 0)
				gameManager.victoryFlag = true;
		} 
		
		else
		{
			gameManager.player1.health -= 5;
			if (gameManager.player2.health <= 0)
				gameManager.victoryFlag = true;
		}
	}

	// Since this card is a sorcery, its effect is activated immediately when it is played and then it is destroyed
	// Only its requirements must be met, and it does not get added to the player's card array
	public override void play ()
	{
		int currentPlayerNumber = gameManager.PlayerTurn;

		// Sorceries can only be played during the main phases
		if (gameManager.PhaseNumber == 1 || gameManager.PhaseNumber == 5) 
		{
			// If the mana cost has been met, activate the card
			// Since only one mana color has been implemented in the prototype, only total cost is needed
			if (currentPlayerNumber == 1 && gameManager.player1.redMana >= TotalCost) 
			{
				effect1 ();
				gameManager.player1.redMana -= TotalCost;
			} 
			
			else if (currentPlayerNumber == 2 && gameManager.player2.redMana >= TotalCost)
			{
				effect1 ();
				gameManager.player2.redMana -= TotalCost;
			}
		}
	}
	
}
