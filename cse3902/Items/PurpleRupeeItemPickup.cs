using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace cse3902;

public class PurpleRupeeItemPickup : IItemPickup
{
    private Sprite PurpleRupeeItem;
    private Vector2 itemPosition = new Vector2(300, 200); // Example positions

    public PurpleRupeeItemPickup(GameContent content)
    {
        PurpleRupeeItem = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(71, 16, 9, 16) });
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        
        PurpleRupeeItem.SetPosition(itemPosition);

        PurpleRupeeItem.Draw(spriteBatch);
    }
    
    public void Update(GameTime gameTime)
    {
    }


}