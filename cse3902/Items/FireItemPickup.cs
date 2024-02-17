using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace cse3902;

public class FireItemPickUp : IItemPickup
{
    private Sprite FireItem;
    private IPlayer player;
    private static int itemIndex = 0; // Consider making this a static property if needed across instances
    private float x = 300, y = 200; // Example positions
    private KeyboardController keyboard;
    public FireItemPickUp(GameContent content, KeyboardController keyboard)
    {
        FireItem = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(71, 16, 9, 16) });
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        FireItem.SetPosition(x, y);

        FireItem.Draw(spriteBatch);
    }

    public void Update(GameTime gameTime)
    {
        throw new System.NotImplementedException();
    }


}