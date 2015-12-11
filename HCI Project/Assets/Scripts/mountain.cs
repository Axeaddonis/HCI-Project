using UnityEngine;
using System.Collections;

public class mountain : Card {

    public mountain() {

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
}
    public override void effect1();
    
}
