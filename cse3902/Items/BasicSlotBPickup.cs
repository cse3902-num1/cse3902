﻿using cse3902.PlayerClasses;
using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;
namespace cse3902.Items
{
    public class BasicSlotBPickup: BasicItemPickup
    {

        Level level;
        public BasicSlotBPickup(Level level) : base(level)
        {

        }

        public override void Pickup(IPlayer player) {
            
        }
    }
}

