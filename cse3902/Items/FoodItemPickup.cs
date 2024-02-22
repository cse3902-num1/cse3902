using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace cse3902;

public class FoodItemPickup : IItemPickup
{
    private Sprite FoodSprite;
    private Vector2 itemPosition = new Vector2(300, 200); // Example positions

    public FoodItemPickup(GameContent content)
    {
        FoodSprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(96, 0, 8, 16) });
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        FoodSprite.SetPosition(itemPosition);

        FoodSprite.Draw(spriteBatch);
    }
    
    public void Update(GameTime gameTime)
    {
    }


}