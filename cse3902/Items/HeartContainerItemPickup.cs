using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace cse3902;

public class HeartContainerItemPickup : IItemPickup
{
    private Sprite HeartContainerSprite;
    private Vector2 itemPosition = new Vector2(300, 200); // Example positions

    public HeartContainerItemPickup(GameContent content)
    {
        HeartContainerSprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(24, 0, 13, 14) });
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        HeartContainerSprite.SetPosition(itemPosition);

        HeartContainerSprite.Draw(spriteBatch);
    }
    
    public void Update(GameTime gameTime)
    {
    }


}