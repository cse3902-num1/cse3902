using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace cse3902;

public class BombItemPickup : IItemPickup
{
    private Sprite BombItem;
    private Vector2 itemPosition = new Vector2(300, 200); // Example positions

    public BombItemPickup(GameContent content)
    {
        BombItem = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(135, 0, 9, 14) });
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        BombItem.SetPosition(itemPosition);

        BombItem.Draw(spriteBatch);
    }

    public void Update(GameTime gameTime)
    {
    }
}
