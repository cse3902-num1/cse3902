using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace cse3902;

public class TriforceItemPickup : IItemPickup
{
    private Sprite TriforceSprite;
    private Vector2 itemPosition = new Vector2(300, 200); // Example positions

    public TriforceItemPickup(GameContent content)
    {
        TriforceSprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(274, 3, 11, 12),
                        new Rectangle(274, 18, 11, 12)
                        }, new Vector2(3.5f, 3.5f));
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        TriforceSprite.SetPosition(itemPosition);

        TriforceSprite.Draw(spriteBatch);
    }
    
    public void Update(GameTime gameTime)
    {
        TriforceSprite.Update(gameTime);
    }


}