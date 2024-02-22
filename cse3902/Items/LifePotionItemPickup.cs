using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace cse3902;

public class LifePotionItemPickup : IItemPickup
{

    private Sprite lifePotionSprite;
    private Vector2 itemPosition = new Vector2(300, 200); // Example positions


    public LifePotionItemPickup(GameContent content)
    {
        lifePotionSprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
            new Rectangle(80, 15, 8, 16),

        });
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        lifePotionSprite.SetPosition(itemPosition);
        lifePotionSprite.Draw(spriteBatch);
    }

    public void Update(GameTime gameTime)
    {
    }
}