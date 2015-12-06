using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	/*	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}*/

	// New Game Started

	// For now assume two players
	
	//Start turn loop
		// Player X turn
		
			// Beginning Phase
				// Untap, Upkeep, and Draw steps

			// Main Phase
				// Player can put cards in front of the camera and hit a "Play" button to put it in the game
					//If it is a land card, or the cost has been met, the card is added to some list or other structure
					// and is considered in play, if cost has not been met then it is not added

				// Player can put cards in front of the camera and hit an "Activate" button to use it
					// If card is in play, or if card is an instant and the cost has been met, effect is activated
						// Lands add appropriate mana
						
						// Other cards have effects activated, and then there is a brief wait period where players
						// can activate other cards in response

			// Combat Phase
				// Attack Step
					// Current player can activate creature cards to attack the other player

				// Defense Step
					// For each attacking creature, other player can activate creature cards to defend

				// Combat Damage Step
					// When one creature defends from another, both creatures lose toughness equal to the other creature's power
					// Any creature that reaches 0 toughness or lower is destroyed and removed from play
					// If a creature is not blocked, defending player loses health equal to creature power
					// If player hits 0 health (starts at 20), he loses

			// Main Phase 2
				//Same as Main Phase 1

			// End phase
				// Any effects that activate/end at end phase activate/end accordingly
				// Move to next player's turn




}
