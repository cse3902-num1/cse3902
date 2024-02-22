using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace cse3902;

public class FireItemPickUp : IItemPickup
{
 
    private Sprite FireSprite;
    private Vector2 itemPosition = new Vector2(300, 200); // Example positions
    

    public FireItemPickUp(GameContent content)
    {
        FireSprite = new Sprite(content.mergedSheet, new List<Rectangle>() {
            new Rectangle(192, 236, 16, 16),
             new Rectangle(535, 237, 16, 16),
             
        });
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        FireSprite.SetPosition(itemPosition);
        FireSprite.Draw(spriteBatch); 
    }

    public void Update(GameTime gameTime)
    {
        FireSprite.Update(gameTime);
    }
}