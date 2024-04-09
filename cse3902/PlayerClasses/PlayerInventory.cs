using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using cse3902.Items;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using cse3902;
using System;
using System.Reflection.Emit;


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

        private Rectangle inventory = new Rectangle(1, 11, 250, 173);
        private Rectangle blackbackground = new Rectangle(1, 11, 11, 11);
        private float blackbackgroundScale = 10000000f;
        private float inventoryScale = 3.5f;
        private Vector2 inventoryPosition = new Vector2(0, -600);
        private bool isDisplayed = true;
      
        public PlayerInventory(GameContent content)
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

        public void Update(GameTime gameTime, List<IController> controllers) {

            if (isDisplayed)
            {
                inventoryPosition = new Vector2(0, -600);
            }
            else
            {

                inventoryPosition = Vector2.Zero;
            }

            //update the vector position of invenroy to be postive when key B is pressed
            if (controllers.Any(c => c.isInventoryDisplayedPressed()))
            {
                isDisplayed = !isDisplayed;

            }  
        }
        

        // Method to prepare the text to be drawn (won't actually draw anything)
        public void Draw(GameContent gameContent, SpriteBatch spriteBatch)
        {
            // Draw the textsprite of items
            drawText(gameContent, spriteBatch);
           
            //this is for drawing the hud
            //draw hearts in life:
            drawHeart(gameContent, spriteBatch);

            //this is to fill slot B
            drawSlotB(gameContent, spriteBatch);
            //fill slot A:
            drawSlotA(gameContent, spriteBatch);

            // Draw blackout effect if inventory is displayed
            if (!isDisplayed)
            {
                spriteBatch.Draw(gameContent.hud, Vector2.Zero, blackbackground, Color.Black, 0f, Vector2.Zero, blackbackgroundScale, SpriteEffects.None, 0f);
            }
            //this is for drawing the inventory
            spriteBatch.Draw(gameContent.hud, inventoryPosition, inventory, Color.White, 0f, Vector2.Zero, inventoryScale, SpriteEffects.None, 0f);



           
        }

        public void drawHeart(GameContent gameContent, SpriteBatch spriteBatch) {
            //draw the heart for the health, initial there are 3 hearts:
            // Draw heart items based on player's health

            Sprite heart = new Sprite(gameContent.hud, new List<Rectangle>() {
                        new Rectangle(645, 117, 8, 8) }
                        , new Vector2(3.5f, 3.5f));

            heart.X = 500;
            heart.Y = 85;

            //should draw all life container first

            Sprite fadedHeart = new Sprite(gameContent.hud, new List<Rectangle>() {
                        new Rectangle(627, 117, 8, 8) }
                   , new Vector2(3.5f, 3.5f));
            fadedHeart.X = heart.X;
            fadedHeart.Y = heart.Y;

            for (int i = 0; i < lifeContainer; i++)
            {
                fadedHeart.X += 16;
                fadedHeart.Draw(spriteBatch);
            }


            //cover the life container with current health
            for (int i = 0; i < health; i++)
            {

                heart.X += 16;
                heart.Draw(spriteBatch);
            }
        }

        public void drawText(GameContent gameContent, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(gameContent.font, "Keys: " + this.Keys, new Vector2(280, 70), Color.White);
            spriteBatch.DrawString(gameContent.font, "Bombs: " + this.Bombs, new Vector2(280, 100), Color.White);
            spriteBatch.DrawString(gameContent.font, "Rubies: " + this.Rubies, new Vector2(280, 30), Color.White);


        }
        public void drawSlotB(GameContent gameContent, SpriteBatch spriteBatch) {
            if (SwordItemPickup.swordIsPicked == true)
            {


                Sprite sword = new Sprite(gameContent.ItemSheet, new List<Rectangle>() {
                        new Rectangle(104, 0, 8, 16) });
                sword.X = 375;
                sword.Y = 60;
                sword.Draw(spriteBatch);
            }
            else if (MagicalSwordItemPickup.isMagicalSwordPicked == true)
            {


                Sprite sword = new Sprite(gameContent.ItemSheet, new List<Rectangle>() {
                        new Rectangle(112, 0, 8, 16) });
                sword.X = 375;
                sword.Y = 60;
                sword.Draw(spriteBatch);
            }
            else if (WhiteSwordItemPickup.isWhiteSwordPicked)
            {
                Sprite sword = new Sprite(gameContent.ItemSheet, new List<Rectangle>() {
                        new Rectangle(104, 16, 8, 16) });
                sword.X = 375;
                sword.Y = 60;
                sword.Draw(spriteBatch);
            }
        }
        public void drawSlotA(GameContent gameContent, SpriteBatch spriteBatch) {
            if (YellowBoomerangItemPickup.isYellowBoomerangPicked)
            {
                Sprite sprite = new Sprite(gameContent.ItemSheet, new List<Rectangle>() {
                        new Rectangle(128, 2, 5, 9) });
                sprite.X = 440;
                sprite.Y = 60;
                sprite.Draw(spriteBatch);
            }
        }
    }
}

