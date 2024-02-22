using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace cse3902;

public class MagicalShieldItemPickup : IItemPickup
{
    private Sprite MagicalShieldSprite;
    private Vector2 itemPosition = new Vector2(300, 200); // Example positions

    public MagicalShieldItemPickup(GameContent content)
    {
        MagicalShieldSprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(120, 0, 8, 16) });
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        MagicalShieldSprite.SetPosition(itemPosition);

        MagicalShieldSprite.Draw(spriteBatch);
    }
    
    public void Update(GameTime gameTime)
    {
    }


}