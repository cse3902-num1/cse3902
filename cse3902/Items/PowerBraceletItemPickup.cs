using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace cse3902;

public class PowerBraceletItemPickup : IItemPickup
{
    private Sprite PowerBraceletSprite;
    private Vector2 itemPosition = new Vector2(300, 200); // Example positions

    public PowerBraceletItemPickup(GameContent content)
    {
        PowerBraceletSprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(175, 0, 10, 16) });
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        PowerBraceletSprite.SetPosition(itemPosition);

        PowerBraceletSprite.Draw(spriteBatch);
    }
    
    public void Update(GameTime gameTime)
    {
    }


}