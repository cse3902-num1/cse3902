using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using cse3902;


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
        private Vector2 HudHeartOrigin = new Vector2(3.5f, 3.5f);

        public PlayerInventory()
        {
            health = 3;
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
            // Draw the quantity of items
            spriteBatch.DrawString(gameContent.font, "Keys: " + this.Keys, PlayerConstant.KeysTextPosition, Color.White);
            spriteBatch.DrawString(gameContent.font, "Bombs: " + this.Bombs, PlayerConstant.BombsPosition, Color.White);
            spriteBatch.DrawString(gameContent.font, "Rubies: " + this.Rubies, PlayerConstant.RubiesTextPosition, Color.White);



            //draw the heart for the health, initial there are 3 hearts:
            // Draw heart items based on player's health
            Vector2 heartPosition = new Vector2(100, 100);
            Sprite heart = new Sprite(gameContent.hud, new List<Rectangle>() {
                        PlayerConstant.HudHeartPosition }
                        , HudHeartOrigin);

            heart.X = 500;
            heart.Y = 85;

            //should draw all life container first
          
                Sprite fadedHeart = new Sprite(gameContent.hud, new List<Rectangle>() {
                        PlayerConstant.HudFadedHeartPosition }
                       , HudHeartOrigin);
                fadedHeart.X = heart.X;
                fadedHeart.Y = heart.Y;

                for (int i = 0; i < lifeContainer; i++)
                {
                    fadedHeart.X += 16;
                    fadedHeart.Draw(spriteBatch);
                }
            

            //cover the life container with current health
            for (int i = 0; i < health; i++) {

                heart.X += 16;
                heart.Draw(spriteBatch);
            }

            Sprite sword = new Sprite(gameContent.ItemSheet, new List<Rectangle>() {
                        PlayerConstant.HudSwordPositionnew });

            sword.X = 375;
            sword.Y = 60;

            if (SwordItemPickup.swordIsPicked == true) {
                sword.Draw(spriteBatch);
            }

           

        }
    }
}

