using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace cse3902;

public class FairyItemPickup : IItemPickup
{
    private Sprite FairySprite;
    private Vector2 itemPosition = new Vector2(300, 200); // Example positions

    public FairyItemPickup(GameContent content)
    {
        FairySprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(39, 0, 7, 15) });
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        FairySprite.SetPosition(itemPosition);

        FairySprite.Draw(spriteBatch);
    }
    
    public void Update(GameTime gameTime)
    {
    }


}