using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace cse3902;

public class RedCandleItemPickup : IItemPickup
{
    private Sprite RedCandleSprite;
    private Vector2 itemPosition = new Vector2(300, 200); // Example positions

    public RedCandleItemPickup(GameContent content)
    {
        RedCandleSprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(160, 0, 8, 16) });
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        RedCandleSprite.SetPosition(itemPosition);

        RedCandleSprite.Draw(spriteBatch);
    }

    public void Update(GameTime gameTime)
    {
    }


}