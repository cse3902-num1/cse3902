using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace cse3902;

public class YellowRupeeItemPickup : IItemPickup
{
    private Sprite YellowRupeeItem;
    private Vector2 itemPosition = new Vector2(300, 200); // Example positions

    public YellowRupeeItemPickup(GameContent content)
    {
        YellowRupeeItem =  new Sprite(content.ItemSheet,new List<Rectangle>() {
                        new Rectangle(71, 0, 9, 16) });
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        YellowRupeeItem.SetPosition(itemPosition);

        YellowRupeeItem.Draw(spriteBatch);
    }
    
    public void Update(GameTime gameTime)
    {
    }


}