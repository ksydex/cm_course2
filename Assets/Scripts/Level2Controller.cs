using System.Collections.Generic;
using System.Linq;
using Common;
using UnityEngine;

public class Level2Controller : LevelControllerBase
{
    public override bool IsMissionSucceeded()
    {
        var list = new List<string> { inventory.isFull[0], inventory.isFull[1], inventory.isFull[2], inventory.isFull[3], inventory.isFull[4] }; 
        return list.Count(x => x == Pickup.Keys.Smile) == 3  && list.Count(x => x == Pickup.Keys.Apple) == 2;
    }

    public override void OnMissionSuccess()
    {
        text.color = Color.green;
    }
}