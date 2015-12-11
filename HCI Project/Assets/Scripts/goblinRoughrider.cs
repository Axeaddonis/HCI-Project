using UnityEngine;
using System.Collections;

public class goblinRoughrider : Card {

    public int power;
    public int toughness;

	public goblinRoughrider( GameManager manager )
	{
        power = 3;
        toughness = 2;
        CardColor = "Red";
        CardName = "Goblin Roughrider";
        CardType = "Creature";
        CardSubType = "Goblin Knight";
        TotalCost = 3;
        RedCost = 1;
        BlueCost = 0;
        GreenCost = 0;
        WhiteCost = 0;
        BlackCost = 0;
        ColorlessCost = 2;
        tapped = false;
		gameManager = manager;
	}

	// The goblin rough rider's only "effect" is being able to attack or defend in the combat phase
    public override void effect1( )
	{	
		// Normally, a creature can only attack, defend, or activate an effect (all of these "tap" the card) once
		// in a full turn cycle (does not "untap" until the player who owns the card starts his next turn
		// This limitation is not implemented in the prototype
		if (tapped == false) 
		{
			// If in attack phase, add him to the attackers
			if (gameManager.PhaseNumber == 2) 
			{
				// Since only one creature has been implemented for the prototype, only the number of attackers is needed
				gameManager.attackingNumber += 1;
			}

			// If in defense phase, add him to the defenders
			else if (gameManager.PhaseNumber == 3)
			{
				// Since only one creature has been implemented for the prototype, only the number of defenders is needed
				gameManager.defendingNumber += 1;
			}
			
		}
	}

	// Puts the goblin rough rider in play if the cost has been met
	public override void play ()
	{
		int currentPlayerNumber = gameManager.PlayerTurn;

		// Most creatures can only be played during the main phases
		if (gameManager.PhaseNumber == 1 || gameManager.PhaseNumber == 5) 
		{
			// Mana cost must be met. Since only one mana color has been implemented for the prototype,
			// only the total cost is needed.
			if (currentPlayerNumber == 1 && gameManager.player1.redMana >= TotalCost) 
			{
				gameManager.player1.addCard (this);
				gameManager.player1.redMana -= TotalCost;
			} 
			
			else if (currentPlayerNumber == 2 && gameManager.player2.redMana >= TotalCost)
			{
				gameManager.player2.addCard (this);
				gameManager.player2.redMana -= TotalCost;
			}
		}
	}


}