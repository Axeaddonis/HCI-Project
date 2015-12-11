using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	int PlayerTurn;
	int PhaseNumber;
	bool PhaseInit;
	bool NextPhaseFlag;

	// Use this for initialization
	void Start () {
		PhaseNumber = 0;
		PlayerTurn = 1;
		PhaseInit = false;
	
	}
	
	// Update is called once per frame
	void Update () {

		// Display which player is taking his turn
			// 


		if( PhaseNumber == 0 )  // Beginning Phase
		{
			// Display information telling player to untap cards, perform upkeep, and draw a card
			// Activate any upkeep effects
		}

		if (PhaseNumber == 1) // Main Phase 1
		{
			// Player can play one land per turn
			// If a land is activated, appropriate mana is added to the player's pool
			// Cards can be played or activated if their costs are met
		}
		
		if (PhaseNumber == 2) // Combat Phase - Attack Step
		{
			// Current player can activate creatures to attack the other player
		}

		if (PhaseNumber == 3) // Combat Phase - Defense Step
		{
			// For each attacking creature, defending player can select creatures to defend with
		}

		if (PhaseNumber == 4)  // Combat Phase - Calculation Step
		{
			// Damage to player and creatures is calculated, creatures who have taken sufficient damage are destroyed
			// Players who have taken sufficient damage lose the game
		}

		if (PhaseNumber == 5) // Main Phase 2
		{
			// Same as Main Phase 1
		}

		if (PhaseNumber == 6) // End Phae
		{
			// Activate end step effects
			// End effects as needed and remove damage to creatures
			// Display information telling the player, if he has more than seven cards, to discard until he has only seven
		}


	}

	// Called when Next Phase Button is pressed
	void NextPhase()
	{
		// If it's not the last phase of the turn, move to the next phase
		if (PhaseNumber < 6) {
			PhaseNumber++;
		} 

		// Otherwise, if it is the last phase, move to the first phase of the next player's turn
		else 
		{
			// First Phase
			PhaseNumber = 0;

			// Move to next player's turn
			if (PlayerTurn == 1)
			{
				PlayerTurn = 2;
			}

			else
			{
				PlayerTurn = 1;
			}
		}

	}


}
