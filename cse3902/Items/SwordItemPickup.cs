using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace cse3902;

public class SwordItemPickup : IItemPickup
{
    private Sprite SwordSprite;
    private Vector2 itemPosition = new Vector2(300, 200); // Example positions

    public SwordItemPickup(GameContent content)
    {
        SwordSprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(104, 0, 8, 16) });
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        SwordSprite.SetPosition(itemPosition);

        SwordSprite.Draw(spriteBatch);
    }
    
    public void Update(GameTime gameTime)
    {
    }


}