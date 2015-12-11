using UnityEngine;
using System.Collections;

public class mountain : Card {

    public mountain( GameManager manager) {

        CardColor = "Red";
        CardName = "Mountain";
        CardType = "Land" ;
        CardSubType = "Mountain";
        TotalCost = 0;
        RedCost = 0;
        BlueCost =0;
        GreenCost = 0;
        WhiteCost = 0;
        BlackCost = 0;
        ColorlessCost = 0;
        tapped = false;
		gameManager = manager;
	}

	// As a land card, the mountain's effect is adding mana to a player's mana pool when activated	
    public override void effect1()
	{
		int currentPlayerNumber = gameManager.PlayerTurn;

		// Normally if a land has been used, it can not be used until the next turn - not limited in prototype
		if (tapped == false) 
		{
			// For the prototype, the implemented cards can only be played in the main phases, so lands only need to be activated
			// during those. However, in the real game, instants and some effects can be activated in any phase so this would 
			// not be limited normally.
			if (gameManager.PhaseNumber == 1 || gameManager.PhaseNumber == 5) 
			{
				if (currentPlayerNumber == 1) 
					gameManager.player1.redMana++;

				else
					gameManager.player2.redMana++;
			}

		}
	}
    
	// Puts the mountain in play	
	public override void play()
	{
		int currentPlayerNumber = gameManager.PlayerTurn;

		// Land cards can only be played in the main phases. Normally there is a limit of one land played per
		// turn, but this limit was not used for this prototype
		if (gameManager.PhaseNumber == 1 || gameManager.PhaseNumber == 5) 
		{
			if (currentPlayerNumber == 1) 
			{
				gameManager.player1.addCard (this);
			} 

			else 
			{
				gameManager.player2.addCard (this);
			}
		}
	}
}
