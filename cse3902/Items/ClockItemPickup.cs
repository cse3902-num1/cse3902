using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace cse3902;

public class ClockItemPickUp : IItemPickup
{
    private Sprite ClockItem;
    private Vector2 itemPosition = new Vector2(300, 200); // Example positions

    public ClockItemPickUp(GameContent content)
    {
        ClockItem = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(57, 0, 12, 16) });
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        ClockItem.SetPosition(itemPosition);

        ClockItem.Draw(spriteBatch);
    }

    public void Update(GameTime gameTime)
    {
    }


}