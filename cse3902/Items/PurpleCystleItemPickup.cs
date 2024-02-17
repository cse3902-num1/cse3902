using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace cse3902;

public class PurpleCystleItemPickUp : IItemPickup
{
    private Sprite PurpleCystleItem;
    private IPlayer player;
    private static int itemIndex = 0; // Consider making this a static property if needed across instances
    private float x = 300, y = 200; // Example positions
    private KeyboardController keyboard;
    private GameContent gameContent;
    public PurpleCystleItemPickUp(GameContent content, KeyboardController keyboard)
    {
        PurpleCystleItem = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(71, 16, 9, 16) });
        this.keyboard = keyboard;
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        PurpleCystleItem.SetPosition(x, y);

        PurpleCystleItem.Draw(spriteBatch);
    }

    public void Update(GameTime gameTime)
    {
        if (keyboard.isNextItemKeyPress())
        {
            FireItemPickUp x = new FireItemPickUp(gameContent, keyboard);
        }
        if (keyboard.isPreviousItemKeyPress())
        {
            // Example key binding for cycling to previous item
            // return previous class;
        }
        PurpleCystleItem.Update(gameTime);
    }


}