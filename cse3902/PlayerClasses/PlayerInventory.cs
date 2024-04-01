using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

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
        // Method to prepare the text to be drawn (won't actually draw anything)
        public void Draw(GameContent gameContent, SpriteBatch spriteBatch)
        {
            // Draw the quantity of keys

            spriteBatch.DrawString(gameContent.font, "Keys: " + this.Keys, new Vector2(280, 70), Color.White);
            spriteBatch.DrawString(gameContent.font, "Bombs: " + this.Bombs, new Vector2(280, 100), Color.White);
            spriteBatch.DrawString(gameContent.font, "Rubies: " + this.Rubies, new Vector2(280, 30), Color.White);

        }
    }
}

