using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace cse3902;

public class RedHeartItemPickUp : IItemPickup
{
    private Sprite RedHeartItem;
    private Vector2 itemPosition = new Vector2(300, 200); // Example positions

    public RedHeartItemPickUp(GameContent content)
    {
        RedHeartItem = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(0, 0, 7, 7) });
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        RedHeartItem.SetPosition(itemPosition);

        RedHeartItem.Draw(spriteBatch);
    }
    
    public void Update(GameTime gameTime)
    {
    }


}