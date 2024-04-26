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
using cse3902.Enemy;


namespace cse3902.PlayerClasses
{
    public class PlayerInventory
    {
        public Vector2 Position { set; get; }

        public int lifeContainer = 5;


        public bool hasMap { get; set; }
        public bool BowUnlocked { get; set; }
        public bool hasCompass { get; set; }
        public int health { get; set; }
        public int Rubies { get; set; }
        public int Keys { get; set; }
        public int Bombs { get; set; }
        public int Triforce { get; set; }


        private int count = 0;
        private int boxH = 0;
        private int boxW = 0;
        private int boxCount = 0;
        private int slotAindex = 0;

        private bool isDisplayed = true;
        private bool isAPressed = false;
        private bool isBPressed = false;
        private Sprite sprite;
        private Sprite map;
        private Sprite compass;
        private Sprite selectBox;
        private IItemPickup itemCopy;
        private IItemPickup itemCopy2;
        private IItemPickup itemCopy3;

        private IEnumerable<TriforceItemPickup> triforceList;
        private IEnumerable<Dragon> dragonList;

        public static List<IItemPickup> inventoryItems = new List<IItemPickup>();
        /* sword items List array */
        public static List<BasicSlotBPickup> slotBItems = new List<BasicSlotBPickup>();
        public static List<BasicSlotAPickup> slotAItems = new List<BasicSlotAPickup>();
        public PlayerInventory(GameContent content)
        {
            health = 5;
            BowUnlocked = true;
            Rubies = 0;
            Keys = 0;
            hasMap = false;
            hasCompass = false;
            Bombs = 0;
            Triforce = 0;

            sprite = new Sprite(content.hud, new List<Rectangle>() { Constant.HudSprite }, Constant.HudOrigin, Constant.HudScaleFactor);
            map = new Sprite(content.ItemSheet, new List<Rectangle>() { PlayerInventoryConstant.MapSourceRect });
            map.Position = new Vector2(PlayerInventoryConstant.MapPositionX, PlayerInventoryConstant.MapPositionY);
            compass = new Sprite(content.ItemSheet, new List<Rectangle>() { ItemsConstant.CompassItemSourceRect });
            compass.Position = new Vector2(PlayerInventoryConstant.CompassPositionX, PlayerInventoryConstant.CompassPositionY);
            selectBox = new Sprite(content.hud, new List<Rectangle>() { PlayerInventoryConstant.SelectBoxSourceRect });
            selectBox.Position = new Vector2(PlayerInventoryConstant.SelectBoxBasePositionX, PlayerInventoryConstant.SelectBoxBasePositionY) + Position;
        }

        public void Update(GameTime gameTime, List<IController> controllers)
        {

            if (isDisplayed)
            {
                PlayerInventoryConstant.InventoryPosition = PlayerInventoryConstant.NewInventoryPosition;
            }
            else
            {

                PlayerInventoryConstant.InventoryPosition = Vector2.Zero;
            }

            //update the vector position of invenroy to be postive when key B is pressed
            if (controllers.Any(c => c.isInventoryDisplayedPressed()))
            {
                isDisplayed = !isDisplayed;

            }
            if (controllers.Any(c => c.isSwitchSlotAPressed()))
            {
                isAPressed = true;


                if (slotAindex < slotAItems.Count - 1)
                {
                    slotAindex++;
                }
                else
                {
                    slotAindex = 0;
                }


            }
            if (controllers.Any(c => c.isSwitchSlotBPressed()))
            {
                isBPressed = true;
                boxCount++;
                if (boxCount < slotBItems.Count)
                {
                    boxW++;
                    if (boxW > 7)
                    {
                        boxW = 0;
                        boxH++;
                    }
                }
                else
                {
                    boxCount = 0;
                    boxW = 0;
                    boxH = 0;
                }

            }
        }


        // Method to prepare the text to be drawn (won't actually draw anything)
        public void Draw(GameContent gameContent, SpriteBatch spriteBatch, Level Level)
        {

            // Draw the textsprite of items
            drawText(gameContent, spriteBatch, 30);


            //this is for drawing the hud
            //draw hearts in life:
            drawHeart(gameContent, spriteBatch, 85);

            //this is to fill slot A
            drawSlotA(gameContent, spriteBatch, 69);
            //fill slot B:

            drawSlotB(gameContent, spriteBatch, 69) ;
           

            // Draw blackout effect if inventory is displayed and draw the other things
            if (!isDisplayed)
            {
                drawBlackEffect(gameContent, spriteBatch);


                drawRadarToHud(gameContent, spriteBatch,Level);
               

                drawMainInventory(gameContent, spriteBatch);

                
                //this is to draw in the inventory middle:
                drawRadar(gameContent, spriteBatch,Level);
                


            }
        }
        public void drawRadarToHud(GameContent gameContent, SpriteBatch spriteBatch, Level Level) {
            //draw play dot on the hud
            Level.playerDot.Position = Level.player.Position / 28f + Position + new Vector2(55, 5 + 175 * 3.5f);
            Level.playerDot.Draw(spriteBatch);
            //draw triforce locaion on the hud
            triforceList = Level.Items.OfType<TriforceItemPickup>();
            foreach (TriforceItemPickup t in triforceList)
            {
                Level.triforceDot.Position = t.Position / 28f + Position + new Vector2(55, 5 + 175 * 3.5f);
                Level.triforceDot.Draw(spriteBatch);
            }
            //draw dragons locaion on the hud
            dragonList = Level.Enemies.OfType<Dragon>();
            foreach (Dragon dragon in dragonList)
            {

                Level.enemyDot.Position = dragon.Position / 28f + Position + new Vector2(55, 5 + 175 * 3.5f);
                Level.enemyDot.Draw(spriteBatch);
            }
        }
        public void drawBlackEffect(GameContent gameContent, SpriteBatch spriteBatch) {

            spriteBatch.Draw(gameContent.hud, Vector2.Zero + Position, PlayerInventoryConstant.BlackBackground, Color.Black, 0f, Vector2.Zero, PlayerInventoryConstant.BlackBackgroundScale, SpriteEffects.None, 0f);

            sprite.Position = PlayerInventoryConstant.blackoutPosition + Position;
         

            sprite.Draw(spriteBatch);
        }

        public void drawMainInventory(GameContent gameContent, SpriteBatch spriteBatch) {
            //this is for drawing the inventory
            spriteBatch.Draw(gameContent.hud, PlayerInventoryConstant.InventoryPosition + Position, PlayerInventoryConstant.Inventory, Color.White, 0f, Vector2.Zero, PlayerInventoryConstant.InventoryScale, SpriteEffects.None, 0f);

            drawText(gameContent, spriteBatch, 184 * 3.5f);
            drawSlotA(gameContent, spriteBatch, 194 * 3.5f + 18);
            drawSlotB(gameContent, spriteBatch, 194 * 3.5f);
            drawHeart(gameContent, spriteBatch, 200 * 3.5f);

            Vector2 pos = new Vector2(476, 186) + Position;
            selectBox.Position = pos - new Vector2(5, 0) - new Vector2(16, 16);
            foreach (IItemPickup i in slotBItems)
            {
                i.Position = pos;
                pos.X += 40;
                count++;
                if (count > 7)
                {
                    pos.Y += 70;
                    pos.X = 476;
                    count = 0;
                }
                i.Draw(spriteBatch);
            }

            selectBox.X += 40 * boxW;
            selectBox.Y += 70 * boxH;

            if (slotBItems.Count > 0)
            {
                selectBox.Draw(spriteBatch);
                // Holding item drawing
                itemCopy = itemCopy3;
                itemCopy.Position = PlayerInventoryConstant.itemcopy + Position;
                itemCopy.Draw(spriteBatch);
                // Slot B drawing
                itemCopy2 = itemCopy;
                itemCopy2.Position = PlayerInventoryConstant.itemcopt2offset + Position;

                itemCopy2.Draw(spriteBatch);
            }

            if (hasMap)
            {
                map.Position = new Vector2(160, 380) + Position + new Vector2(8, 8);
                map.Draw(spriteBatch);
            }
            if (hasCompass)
            {
                compass.Position = new Vector2(160, 540) + Position + new Vector2(8, 8);
                compass.Draw(spriteBatch);
            }

            //press b to switch weapons in the inventory
            if (isBPressed)
            {
                if (slotBItems.Count != 0)
                {
                    slotBItems[0].Draw(spriteBatch);
                }
                isBPressed = false;
            }
            //press V to switch swords in slot A
            if (isAPressed)
            {
                if (slotAItems.Count != 0)
                {
                    slotAItems[0].Draw(spriteBatch);
                }
                isAPressed = false;
            }

        }

        public void drawRadar(GameContent gameContent, SpriteBatch spriteBatch, Level Level) {

            //draw the minimap to the left bottom corner:
            //draw play dot on the hud
            Level.playerDot.Position = Level.player.Position / 28f + Position + PlayerInventoryConstant.radaroffset;
            Level.playerDot.Draw(spriteBatch);
            //draw triforce locaion on the hud

            foreach (TriforceItemPickup t in triforceList)
            {
                Level.triforceDot.Position = t.Position / 28f + Position + PlayerInventoryConstant.radaroffset;
                Level.triforceDot.Draw(spriteBatch);
            }
            //draw dragons locaion on the hud

            foreach (Dragon dragon in dragonList)
            {

                Level.enemyDot.Position = dragon.Position / 28f + Position + PlayerInventoryConstant.radaroffset;
                Level.enemyDot.Draw(spriteBatch);
            }
        }

        public void drawHeart(GameContent gameContent, SpriteBatch spriteBatch, float y)
        {
            //draw the heart for the health, initial there are 3 hearts:
            // Draw heart items based on player's health

            Sprite heart = new Sprite(gameContent.hud, new List<Rectangle>() {
                        PlayerConstant.HudHeartPosition }
                        , PlayerInventoryConstant.HudHeartOrigin);

            heart.X = 500;
            heart.Y = y;
            heart.Position += Position;

            //should draw all life container first

            Sprite fadedHeart = new Sprite(gameContent.hud, new List<Rectangle>() {
                       PlayerInventoryConstant.fadeHeart }
                   , new Vector2(3.5f, 3.5f));
            fadedHeart.X = heart.X;
            fadedHeart.Y = heart.Y;
            // fadedHeart.Position += Position;

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
            spriteBatch.DrawString(gameContent.font, "Triforces: " + this.Triforce, new Vector2(280, y + 40) + Position, Color.White);
            spriteBatch.DrawString(gameContent.font, "Bombs: " + this.Bombs, new Vector2(280, y + 70) + Position, Color.White);
            spriteBatch.DrawString(gameContent.font, "Rubies: " + this.Rubies, new Vector2(280, y) + Position, Color.White);


        }
        public void drawSlotB(GameContent gameContent, SpriteBatch spriteBatch, float y)
        {
            if (slotBItems.Count > 0)
            {
                itemCopy3 = slotBItems[boxCount];
                itemCopy3.Position = new Vector2(384, y) + Position;

                itemCopy3.Draw(spriteBatch);
            }

        }
        public void drawSlotA(GameContent gameContent, SpriteBatch spriteBatch, float y)
        {
            if (slotAItems.Count > 0)
            {
                IItemPickup x = slotAItems[slotAindex];

                x.Position = new Vector2(458, y) + Position;

                x.Draw(spriteBatch);
            }

        }
    }
}
