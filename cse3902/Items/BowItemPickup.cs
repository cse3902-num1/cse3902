using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace cse3902;

public class BowItemPickup : IItemPickup
{
    private Sprite BowSprite;
    private Vector2 itemPosition = new Vector2(300, 200); // Example positions

    public BowItemPickup(GameContent content)
    {
        BowSprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(144, 0, 8, 16) });
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        BowSprite.SetPosition(itemPosition);

        BowSprite.Draw(spriteBatch);
    }

    public void Update(GameTime gameTime)
    {
    }


}