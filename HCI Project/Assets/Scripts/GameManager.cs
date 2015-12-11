using UnityEngine;
using UnityEngine.UI;
using System.Collections;


// GameManager handles all the game rules based on the Magic: The Gathering rulebook
public class GameManager : MonoBehaviour {

	public Player player1;				// Player 1
	public Player player2;				// Player 2
	public int PlayerTurn;				// Indicates which player is taking his turn
	public int attackingNumber;			// Number of attacking creatures during the combat phase
	public int defendingNumber;			// Number of defending creatures during the combat phase
	int DefendingPlayerTurn;			// Player number of the defending player
	int DefendingPlayerOriginalHealth;	// Used to prevent health from constantly decreasing during calculation phase
	public int PhaseNumber;				// Indicates turn phase
	bool PhaseInit;						// Unused - would allow the implementation of effects or game rules that happen
										// at the beginning of a given phase without player input
	bool NextPhaseFlag;					// Unused - would prevent player from moving to the next phase if an action is required or a wait needed
	public bool victoryFlag;			// Indicates when a player has won
	public Card mountainCard;			// Class that implements the Mountain card
	public Card lavaAxeCard;			// Class that implements the Lava Axe card
	public Card goblinRoughRiderCard;	// Class that implements the Goblin Rough Rider card
	int damage;							// Used for damace calculation during combat phase

	// Use this for initialization
	void Start () {
		PhaseNumber = 0;
		PlayerTurn = 1;
		DefendingPlayerTurn = 2;
		PhaseInit = false;
		player1 = new Player (1);
		player2 = new Player (2);
		mountainCard = new mountain (this);
		lavaAxeCard = new lava_axe (this);
		goblinRoughRiderCard = new goblinRoughrider (this);
		victoryFlag = false;
	}
	
	// Update is called once per frame
	void Update () {

		// Access all of the UI text objects
		// This accesses the text used to indicate the current game phase
		GameObject phasetext = GameObject.Find ("PhaseText");
		Text[] phaseTextValue = phasetext.GetComponentsInChildren<Text> ();

		// This accesses the text used to provide instruction for the current game phase
		GameObject detailstext = GameObject.Find ("DetailsText");
		Text[] detailsTextValue = detailstext.GetComponentsInChildren<Text> ();

		// This accesses and manages the card text for player 1
		GameObject P1Cards = GameObject.Find ("P1CardNames");
		Text[] P1CardsText = P1Cards.GetComponentsInChildren<Text> ();
		P1CardsText [0].text = player1.getCardsString ();

		// This accesses and manages the card text for player 2
		GameObject P2Cards = GameObject.Find ("P2CardNames");
		Text[] P2CardsText = P2Cards.GetComponentsInChildren<Text> ();
		P2CardsText [0].text = player2.getCardsString ();

		// This accesses and manages the player health text
		GameObject healthtext = GameObject.Find ("HealthText");
		Text[] healthTextValue = healthtext.GetComponentsInChildren<Text> ();
		healthTextValue [0].text = "Player 1 Health: " + player1.health + "\nPlayer 2 Health: " + player2.health;

		// This accesses and manages the mana pool text
		GameObject manatext = GameObject.Find ("ManaText");
		Text[] manaTextValue = manatext.GetComponentsInChildren<Text> ();
		manaTextValue [0].text = "Player 1 Mana: " + player1.redMana + "\nPlayer 2 Mana: " + player2.redMana;

		// During each phase, display the current player and the game phase
		if( PhaseNumber == 0 )  // Beginning Phase
		{
			phaseTextValue [0].text = "Player " + PlayerTurn + ": Beginning Phase";

			// Display information telling player to untap cards, perform upkeep, and draw a card
			detailsTextValue[0].text = "Untap cards, perform upkeep step, draw one card";

			// Activate any upkeep effects - not implemented
		}

		if (PhaseNumber == 1) // Main Phase 1
		{
			phaseTextValue [0].text = "Player " + PlayerTurn + ": Main Phase 1";
			detailsTextValue[0].text = "You can play cards during the main phase. Note that only one land can be played per turn.";
			// Player can normally play one land per turn - not limited in prototype
			// If a land is activated, appropriate mana is added to the player's pool - done by the Activate button on land cards
			// Cards can be played or activated if their costs are met - done by Play/Activate buttons on each card
		}


		// All combat phases have been simplified for the prototype
		if (PhaseNumber == 2) // Combat Phase - Attack Step
		{
			phaseTextValue [0].text = "Player " + PlayerTurn + ": Combat Phase - Attack Step";
			detailsTextValue[0].text = ("Choose creatures you want to use to attack \n \n" 
			                            + "Attacking with " + attackingNumber + " creature(s)");
			// Current player can activate creatures to attack the other player
			// In this prototype, only one creature is implemented, so power and toughness values do not need to be accessed
		}

		if (PhaseNumber == 3) // Combat Phase - Defense Step
		{
			phaseTextValue [0].text = "Player " + DefendingPlayerTurn + ": Combat Phase - Defense Step";
			detailsTextValue[0].text = ("Choose creatures you want to use to defend \n \n" 
										+ "Defending with " + defendingNumber + " creature(s)");

			// For each attacking creature, defending player can select creatures to defend with
			// Since combat has been simplified for the prototype, defending player does not have to target a 
			// creature to defend against

			// Get the defending player's original health before calculations begin
			if (DefendingPlayerTurn == 1)
			{
				DefendingPlayerOriginalHealth = player1.health;
			}

			else
				DefendingPlayerOriginalHealth = player2.health;
		}

		if (PhaseNumber == 4)  // Combat Phase - Calculation Step
		{
			phaseTextValue [0].text = "Player " + PlayerTurn + ": Combat Phase - Calculation Step";
			// Damage to player and creatures is calculated, creatures who have taken sufficient damage are destroyed

			// Since only one creature is implemented for the prototype, and that creature is strong enough to destroy
			// itself, combat simply becomes a matter of numbers
			if (attackingNumber >= 1)
			{
				// If there are more attackers, deal appropriate damage
				if (attackingNumber > defendingNumber)
				{
					damage = 3 * (attackingNumber - defendingNumber);
				}

				// Otherwise, defending player 1ins
				else
					damage = 0;

				// Change player health as necessary
				if (DefendingPlayerTurn == 1)
				{
					player1.health = DefendingPlayerOriginalHealth - damage;
				}

				else
					player2.health = DefendingPlayerOriginalHealth - damage;

				// Players who have taken sufficient damage lose the game
				if (DefendingPlayerOriginalHealth - damage <= 0)
				{
					victoryFlag = true;

					if(DefendingPlayerTurn == 1)
					{
						detailsTextValue[0].text = attackingNumber + " creature(s) attacking \n" + defendingNumber +
							" creature(s) defending.\n" + damage + " damage dealt" + "\n \n Player 2 Wins!";
					}

					else
					{
						detailsTextValue[0].text = attackingNumber + " creature(s) attacking \n" + defendingNumber +
							" creature(s) defending.\n" + damage + " damage dealt" + "\n \n Player 1 Wins!";
					}
				}

				// Otherwise, damage goes through and the game continues
				else
				{
					detailsTextValue[0].text = attackingNumber + " creature(s) attacking \n" + defendingNumber +
										   " creature(s) defending.\n" + damage + " damage dealt";
				}
			}

			// If player did not attack, indicate this
			else
				detailsTextValue[0].text = "No Attack";
			
		}
		
		if (PhaseNumber == 5) // Main Phase 2
		{
			phaseTextValue [0].text = "Player " + PlayerTurn + ": Main Phase 2";
			detailsTextValue[0].text = "You can play cards during the main phase. Note that only one land can be played per turn.";
			// Same as Main Phase 1
		}

		if (PhaseNumber == 6) // End Phase
		{
			phaseTextValue [0].text = "Player " + PlayerTurn + ": End Phase";

			// Display information telling the player, if he has more than seven cards, to discard until he has only seven
			detailsTextValue[0].text = "End step effects activated. If you have more than seven cards, discard until you have seven.";

			// Normally, end step effects would be managed, and any creature damage would be returned to 0

			// Reset values as needed before next turn
			attackingNumber = 0;
			defendingNumber = 0;
		}


	}

	// Called when Next Phase Button is pressed
	public void NextPhase()
	{
		if (victoryFlag != true) {
			// If it's not the last phase of the turn, move to the next phase
			if (PhaseNumber < 6) {
				PhaseNumber++;
			} 

			// Otherwise, if it is the last phase, move to the first phase of the next player's turn
			else {
				// First Phase
				PhaseNumber = 0;

				// Move to next player's turn
				if (PlayerTurn == 1) {
					PlayerTurn = 2;
					DefendingPlayerTurn = 1;
				} else {
					PlayerTurn = 1;
					DefendingPlayerTurn = 2;
				}
			}

		}
	}

	// Called when the mountain's play button is pressed - puts it in play
	public void playMountain()
	{
		mountainCard.play ();
	}

	// Called when the lava axe's play button is pressed and costs are met - puts it in play
	// Since lava axe is a sorcery, it is also activated instantly and does not have an activate button, and is not added to player cards
	public void playLavaAxe()
	{
		lavaAxeCard.play ();
	}

	// Called when the rough rider's play button is pressed and costs are met - puts it in play
	public void playRoughRider()
	{
		goblinRoughRiderCard.play ();
	}

	// Called when mountain's activate button is pressed - adds one red mana to the player's mana pool
	public void activateMountain()
	{
		mountainCard.effect1 ();
	}

	// Called when the rough rider's activate button is pressed during combat phase - adds it to combat
	public void activateRoughRider()
	{
		goblinRoughRiderCard.effect1 ();
	}
}
