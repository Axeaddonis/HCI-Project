using UnityEngine;
using System.Collections;

public class demolish : Card {

    public demolish()
    {

        CardColor = "Red";
        CardName = "Demolish";
        CardType = "Sorcery";
        CardSubType = "none";
        TotalCost = 4;
        RedCost = 1;
        BlueCost = 0;
        GreenCost = 0;
        WhiteCost = 0;
        BlackCost = 0;
        ColorlessCost = 3;
        tapped = true;
    }

    public override void effect1();

}
