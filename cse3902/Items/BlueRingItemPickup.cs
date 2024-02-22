using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace cse3902;

public class BlueRingItemPickup : IItemPickup
{
    private Sprite BlueRingSprite;
    private Vector2 itemPosition = new Vector2(300, 200); // Example positions

    public BlueRingItemPickup(GameContent content)
    {
        BlueRingSprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(168, 18, 8, 16) });
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        BlueRingSprite.SetPosition(itemPosition);

        BlueRingSprite.Draw(spriteBatch);
    }

    public void Update(GameTime gameTime)
    {
    }


}