﻿using System;
namespace cse3902.Player
{
	public class PlayerInventory
	{
		private bool hasMap;
        private bool BowUnlocked;
        private bool hasCompass;
        private int health;
        private int Rubies;
		private int Keys;
      
        public PlayerInventory()
		{

            BowUnlocked = true;
            Rubies = 0;
            Keys = 0;
            hasMap = false;
            hasCompass = false;
        }
	}
}

