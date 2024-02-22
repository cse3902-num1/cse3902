using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace cse3902;

public class RupyItemPickup : IItemPickup
{
    private Sprite RupySprite;
    private Vector2 itemPosition = new Vector2(300, 200); // Example positions

    public RupyItemPickup(GameContent content)
    {
        RupySprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(71, 16, 9, 16) ,
                        new Rectangle(71, 0, 9, 16)}, new Vector2(3.5f, 3.5f));
    }


    public void Draw(SpriteBatch spriteBatch)
    {

        RupySprite.SetPosition(itemPosition);

        RupySprite.Draw(spriteBatch);
    }
    
    public void Update(GameTime gameTime)
    {
        RupySprite.Update(gameTime);
    }


}