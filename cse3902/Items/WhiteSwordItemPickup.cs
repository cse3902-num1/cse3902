using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace cse3902;

public class WhiteSwordItemPickup : IItemPickup
{
    private Sprite WhiteSwordSprite;
    private Vector2 itemPosition = new Vector2(300, 200); // Example positions

    public WhiteSwordItemPickup(GameContent content)
    {
        WhiteSwordSprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(104, 16, 8, 16) });
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        WhiteSwordSprite.SetPosition(itemPosition);

        WhiteSwordSprite.Draw(spriteBatch);
    }
    
    public void Update(GameTime gameTime)
    {
    }


}