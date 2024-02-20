using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace cse3902;

public class RedHeartContainerItemPickUp : IItemPickup
{
    private Sprite RedHeartContainerItem;
    private Vector2 itemPosition = new Vector2(300, 200); // Example positions

    public RedHeartContainerItemPickUp(GameContent content)
    {
        RedHeartContainerItem = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(24, 0, 13, 14) });
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        RedHeartContainerItem.SetPosition(itemPosition);

        RedHeartContainerItem.Draw(spriteBatch);
    }
    
    public void Update(GameTime gameTime)
    {
    }


}