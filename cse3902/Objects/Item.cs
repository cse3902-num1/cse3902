using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902.Objects
{
    public class Item
    {
        private List<Sprite> items;
        private static int itemIndex = 0; // Consider making this a static property if needed across instances
        private float x = 300, y = 200; // Example positions
        private KeyboardController keyboard;
        
        public Item(GameContent content,KeyboardController keyboard)
        {

            // Initialize your items similar to how you've initialized blocks
            items = new List<Sprite>() {
                // Populate with item sprites
                { new Sprite(content.ItemSheet,new List<Rectangle>() {
                        new Rectangle(71, 16, 9, 16) }) 
                },
                { new Sprite(content.SpriteSheetLinkAdditionItems, new List<Rectangle>() {
                        new Rectangle(191, 185, 16, 16) })
                },
                { new Sprite(content.ItemSheet,new List<Rectangle>() {
                        new Rectangle(71, 16, 9, 16) }) 
                },
                { new Sprite(content.ItemSheet,new List<Rectangle>() {
                        new Rectangle(71, 0, 9, 16) })
                },
                { new Sprite(content.ItemSheet,new List<Rectangle>() {
                        new Rectangle(274, 3, 11, 12) })
                },
                { new Sprite(content.ItemSheet,new List<Rectangle>() {
                        new Rectangle(274, 18, 11, 12) })
                },
                { new Sprite(content.ItemSheet,new List<Rectangle>() {
                        new Rectangle(87, 0, 8, 15) })
                },
                { new Sprite(content.ItemSheet,new List<Rectangle>() {
                        new Rectangle(240, 0, 8, 15) })
                },
                { new Sprite(content.ItemSheet,new List<Rectangle>() {
                        new Rectangle(0, 0, 7, 7) })
                },
                { new Sprite(content.ItemSheet,new List<Rectangle>() {
                        new Rectangle(0, 8, 7, 7) })
                },
                { new Sprite(content.ItemSheet,new List<Rectangle>() {
                        new Rectangle(24, 0, 13, 14) })
                },
                { new Sprite(content.ItemSheet,new List<Rectangle>() {
                        new Rectangle(39, 0, 7, 15) })
                },
                { new Sprite(content.ItemSheet,new List<Rectangle>() {
                        new Rectangle(257, 1, 12, 13) })
                },
                { new Sprite(content.ItemSheet,new List<Rectangle>() {
                        new Rectangle(57, 0, 12, 16) })
                },
                { new Sprite(content.ItemSheet,new List<Rectangle>() {
                        new Rectangle(144, 0, 8, 16) })
                },
                { new Sprite(content.ItemSheet,new List<Rectangle>() {
                        new Rectangle(128, 2, 5, 9) })
                },
                { new Sprite(content.ItemSheet,new List<Rectangle>() {
                        new Rectangle(135, 0, 9, 14) })
                }

                
                // Add more as needed
            };
            this.keyboard = keyboard;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
         
            // Draw the current item based on itemIndex
            items[itemIndex].SetPosition(x, y);

            items[itemIndex].Draw(spriteBatch);

            
        }

        public void Update(GameTime gameTime)
        {
            
            //Debug.WriteLine(items[itemIndex].ToString());
            // Cycle through items similar to how you cycle through blocks
            if (keyboard.isNextItemKeyPress())
            {
                // Example key binding for cycling to next item
                CycleToNextItem();
            }
            if (keyboard.isPreviousItemKeyPress()) 
            {
                // Example key binding for cycling to previous item
                CycleToPreviousItem();
            }
            items[itemIndex].Update(gameTime);
        }

        private void CycleToNextItem()
        {
            itemIndex = (itemIndex + 1) % items.Count;
        }

        private void CycleToPreviousItem()
        {
            itemIndex = (itemIndex - 1 + items.Count) % items.Count;
        }
    }
}
