using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace cse3902;

public class RedRingItemPickup : IItemPickup
{
    private Sprite RedRingSprite;
    private Vector2 itemPosition = new Vector2(300, 200); // Example positions

    public RedRingItemPickup(GameContent content)
    {
        RedRingSprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(168, 2, 8, 16) });
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        RedRingSprite.SetPosition(itemPosition);

        RedRingSprite.Draw(spriteBatch);
    }

    public void Update(GameTime gameTime)
    {
    }


}