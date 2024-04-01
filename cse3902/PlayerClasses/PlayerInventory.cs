﻿using System;
namespace cse3902.PlayerClasses
{
	public class PlayerInventory
	{
        public bool hasMap;
        public bool BowUnlocked;
        public bool hasCompass;
        public int health;
        public int Rubies;
		public int Keys;
        public int Bombs;
        public int Triforce;
        public int lifeContainer = 3;
      
        public PlayerInventory()
		{
            health = lifeContainer;
            BowUnlocked = true;
            Rubies = 0;
            Keys = 0;
            hasMap = false;
            hasCompass = false;
            Bombs = 0;
            Triforce = 0;

        }
	}
}

