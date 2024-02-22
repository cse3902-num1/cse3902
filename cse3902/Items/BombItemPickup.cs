using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace cse3902;

public class BombItemPickup : IItemPickup
{
    private Sprite BombSprite;
    private Vector2 itemPosition = new Vector2(300, 200); // Example positions

    public BombItemPickup(GameContent content)
    {
        BombSprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(135, 0, 9, 14) });
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        BombSprite.SetPosition(itemPosition);

        BombSprite.Draw(spriteBatch);
    }

    public void Update(GameTime gameTime)
    {
    }
}
