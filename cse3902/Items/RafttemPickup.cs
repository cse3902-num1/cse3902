using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace cse3902;

public class RaftItemPickup : IItemPickup
{
    private Sprite RaftSprite;
    private Vector2 itemPosition = new Vector2(300, 200); // Example positions

    public RaftItemPickup(GameContent content)
    {
        RaftSprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(192, 0, 16, 16) });
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        RaftSprite.SetPosition(itemPosition);

        RaftSprite.Draw(spriteBatch);
    }
    
    public void Update(GameTime gameTime)
    {
    }


}