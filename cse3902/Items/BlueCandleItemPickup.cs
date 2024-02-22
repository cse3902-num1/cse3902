using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace cse3902;

public class BlueCandleItemPickup : IItemPickup
{
    private Sprite BlueCandleSprite;
    private Vector2 itemPosition = new Vector2(300, 200); // Example positions

    public BlueCandleItemPickup(GameContent content)
    {
        BlueCandleSprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(160, 16, 8, 16) });
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        BlueCandleSprite.SetPosition(itemPosition);

        BlueCandleSprite.Draw(spriteBatch);
    }
    
    public void Update(GameTime gameTime)
    {
    }


}