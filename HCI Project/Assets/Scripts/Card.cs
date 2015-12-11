using UnityEngine;
using System.Collections;


public abstract class Card : MonoBehaviour 
{

	public string CardColor;
	public string CardName;
	public string CardType;
	public string CardSubType;
	public int TotalCost;
	public int RedCost;
	public int BlueCost;
	public int GreenCost;
	public int WhiteCost;
	public int BlackCost;
	public int ColorlessCost;
	public bool tapped;
	
	public abstract void effect1();
}
