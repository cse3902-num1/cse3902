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
using cse3902.RoomClasses;


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

        private Rectangle inventory = new Rectangle(1, 11, 250, 173);
        private Rectangle blackbackground = new Rectangle(1, 11, 11, 11);
        private float blackbackgroundScale = 10000000f;
        private float inventoryScale = 3.5f;
        private Vector2 inventoryPosition = new Vector2(0, -600);
        private bool isDisplayed = true;
        private bool isAPressed = false;
        private bool isBPressed = false;
        Sprite sprite;
        Sprite map;
        Sprite compass;

        public static List<IItemPickup> inventoryItems = new List<IItemPickup>();
        /* sword items List array */
        public static List<BasicSlotBPickup> slotBItems = new List<BasicSlotBPickup>();
        public static List<BasicSlotAPickup> slotAItems = new List<BasicSlotAPickup>();
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

            sprite = new Sprite(content.hud, new List<Rectangle>() { Constant.HudSprite }, Constant.HudOrigin, Constant.HudScaleFactor);
            map = new Sprite(content.ItemSheet, new List<Rectangle>() { new Rectangle(87, 0, 8, 15) });
            map.Position = new Vector2(160, 380);
            compass = new Sprite(content.ItemSheet, new List<Rectangle>() { ItemsConstant.CompassItemSourceRect });
            compass.Position = new Vector2(160, 540);
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
            if (controllers.Any(c => c.isSwitchSlotAPressed()))
            {
                isAPressed = true;
                //draw the item in slot A
                //for (int i = 0; i < slotAItems.Count; i++)
                //{
                //    if(slotAItems[i] is BombItemPickup){
                        
                //    }
                //}
                //get the current item:

            }
            if (controllers.Any(c => c.isSwitchSlotBPressed()))
            {
                isBPressed = true;
                //draw the item in slot B
                //for (int i = 0; i < slotBItems.Count; i++)
                //{
                //    slotBItems[i].Pickup(null);
                //}
            }
        }
        

        // Method to prepare the text to be drawn (won't actually draw anything)
        public void Draw(GameContent gameContent, SpriteBatch spriteBatch)
        {
            // Draw the textsprite of items
            drawText(gameContent, spriteBatch, 30);
           
            //this is for drawing the hud
            //draw hearts in life:
            drawHeart(gameContent, spriteBatch, 85);

            //this is to fill slot B
            drawSlotB(gameContent, spriteBatch, 60);
            //fill slot A:
            drawSlotA(gameContent, spriteBatch, 60);

            

            // Draw blackout effect if inventory is displayed and draw the other things
            if (!isDisplayed)
            {
                spriteBatch.Draw(gameContent.hud, Vector2.Zero, blackbackground, Color.Black, 0f, Vector2.Zero, blackbackgroundScale, SpriteEffects.None, 0f);

                sprite.Position = new Vector2(0, 175*3.5f);
                sprite.Draw(spriteBatch);

                //this is for drawing the inventory
                spriteBatch.Draw(gameContent.hud, inventoryPosition, inventory, Color.White, 0f, Vector2.Zero, inventoryScale, SpriteEffects.None, 0f);

                drawText(gameContent, spriteBatch, 184*3.5f);
                drawSlotA(gameContent, spriteBatch, 194 * 3.5f);
                drawSlotB(gameContent, spriteBatch, 194 * 3.5f);
                drawHeart(gameContent, spriteBatch, 200 * 3.5f);

                Vector2 pos = new Vector2(460, 170);
                int count = 0;
                foreach(IItemPickup i in inventoryItems) {
                    i.Position = pos;
                    pos.X += 40;
                    count++;
                    if (count > 7)
                    {
                        pos.Y += 70;
                        pos.X = 460;
                        count = 0;
                    }
                    i.Draw(spriteBatch);
                }

                if (hasMap)
                {
                    map.Draw(spriteBatch);
                }
                if (hasCompass)
                {
                    compass.Draw(spriteBatch);
                }

                if (isBPressed)
                {
                    if (slotBItems.Count != 0)
                    {
                        slotBItems[0].Draw(spriteBatch);
                    }
                    isBPressed = false;
                }
            }
            

            

        }

        public void drawHeart(GameContent gameContent, SpriteBatch spriteBatch, float y) {
            //draw the heart for the health, initial there are 3 hearts:
            // Draw heart items based on player's health

            Sprite heart = new Sprite(gameContent.hud, new List<Rectangle>() {
                        PlayerConstant.HudHeartPosition }
                        , HudHeartOrigin);

            heart.X = 500;
            heart.Y = y;

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

        public void drawText(GameContent gameContent, SpriteBatch spriteBatch, float y)
        {
            spriteBatch.DrawString(gameContent.font, "Keys: " + this.Keys, new Vector2(280, y+40), Color.White);
            spriteBatch.DrawString(gameContent.font, "Bombs: " + this.Bombs, new Vector2(280, y+70), Color.White);
            spriteBatch.DrawString(gameContent.font, "Rubies: " + this.Rubies, new Vector2(280, y), Color.White);


        }
        public void drawSlotB(GameContent gameContent, SpriteBatch spriteBatch, float y) {
            if (SwordItemPickup.swordIsPicked == true)
            {


                Sprite sword = new Sprite(gameContent.ItemSheet, new List<Rectangle>() {
                        new Rectangle(104, 0, 8, 16) });
                sword.X = 375;
                sword.Y = y;
                sword.Draw(spriteBatch);
            }
            else if (MagicalSwordItemPickup.isMagicalSwordPicked == true)
            {


                Sprite sword = new Sprite(gameContent.ItemSheet, new List<Rectangle>() {
                        new Rectangle(112, 0, 8, 16) });
                sword.X = 375;
                sword.Y = y;
                sword.Draw(spriteBatch);
            }
            else if (WhiteSwordItemPickup.isWhiteSwordPicked)
            {
                Sprite sword = new Sprite(gameContent.ItemSheet, new List<Rectangle>() {
                        new Rectangle(104, 16, 8, 16) });
                sword.X = 375;
                sword.Y = y;
                sword.Draw(spriteBatch);
            }
        }
        public void drawSlotA(GameContent gameContent, SpriteBatch spriteBatch, float y) {
            if (YellowBoomerangItemPickup.isYellowBoomerangPicked)
            {
                Sprite sprite = new Sprite(gameContent.ItemSheet, new List<Rectangle>() {
                        new Rectangle(128, 2, 5, 9) });
                sprite.X = 440;
                sprite.Y = y;
                sprite.Draw(spriteBatch);
            }
        }
    }
}

