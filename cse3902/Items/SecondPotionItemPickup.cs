using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace cse3902;

public class SecondPotionItemPickup : IItemPickup
{
 
    private Sprite secondPotionSprite;
    private Vector2 itemPosition = new Vector2(300, 200); // Example positions
    

    public SecondPotionItemPickup(GameContent content)
    {
        secondPotionSprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
            new Rectangle(80, 0, 8, 16),
             
        });
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        secondPotionSprite.SetPosition(itemPosition);
        secondPotionSprite.Draw(spriteBatch); 
    }

    public void Update(GameTime gameTime)
    {
    }
}