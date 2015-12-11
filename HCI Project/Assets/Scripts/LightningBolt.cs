using UnityEngine;
using System.Collections;

public class LightningBolt : Card {

	public LightningBolt()
	{
		CardColor = "Red";
		CardName = "Lightning Bolt";
		CardType = "Instant";
		CardSubType = "None";
		TotalCost = 1;
		RedCost = 1;
		BlueCost = 0;
		GreenCost = 0;
		WhiteCost = 0;
		BlackCost = 0;
		ColorlessCost = 0;
		tapped = true;
	}

	public override void effect1()
	{

	}
}
