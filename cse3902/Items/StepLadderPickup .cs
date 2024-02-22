using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace cse3902;

public class StepLadderItemPickup : IItemPickup
{
    private Sprite StepLadderSprite;
    private Vector2 itemPosition = new Vector2(300, 200); // Example positions

    public StepLadderItemPickup(GameContent content)
    {
        StepLadderSprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(207, 0, 17, 16) });
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        StepLadderSprite.SetPosition(itemPosition);

        StepLadderSprite.Draw(spriteBatch);
    }
    
    public void Update(GameTime gameTime)
    {
    }


}