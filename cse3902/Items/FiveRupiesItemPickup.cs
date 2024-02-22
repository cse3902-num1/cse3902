using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace cse3902;

public class FiveRupiesItemPickup : IItemPickup

{
    private Sprite FiveRupiesSprite;
    private Vector2 itemPosition = new Vector2(300, 200); // Example positions

    public FiveRupiesItemPickup(GameContent content)
    {
        FiveRupiesSprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(71, 16, 9, 16) });
    }


    public void Draw(SpriteBatch spriteBatch)
    {

        FiveRupiesSprite.SetPosition(itemPosition);

        FiveRupiesSprite.Draw(spriteBatch);
    }
    
    public void Update(GameTime gameTime)
    {
    }


}