using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using UnityEngine;

public class Level1Controller : LevelControllerBase
{
    public override bool IsMissionSucceeded()
        => new List<string> { inventory.isFull[0], inventory.isFull[1], inventory.isFull[2] }.All(x =>
            x == Pickup.Keys.Apple);

    public override void OnMissionSuccess()
    {
        text.color = Color.green;
    }
}