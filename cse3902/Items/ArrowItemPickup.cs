using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace cse3902;

public class ArrowItemPickUp : IItemPickup
{
    private Sprite ArrowItem;
    private Vector2 itemPosition = new Vector2(300, 200); // Example positions

    public ArrowItemPickUp(GameContent content)
    {
        ArrowItem = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(144, 0, 8, 16) });
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        ArrowItem.SetPosition(itemPosition);

        ArrowItem.Draw(spriteBatch);
    }

    public void Update(GameTime gameTime)
    {
    }


}