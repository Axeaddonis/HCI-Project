using UnityEngine;
using System.Collections;

public class goblinRoughrider : Card {

    public int power;
    public int toughness;

    public goblinRoughrider()
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
        tapped = true;
    }

    public override void effect1();

}