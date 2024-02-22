using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace cse3902;

public class HeartItemPickup : IItemPickup
{
    private Sprite HeartItem;
    private Vector2 itemPosition = new Vector2(300, 200); // Example positions

    public HeartItemPickup(GameContent content)
    {
        HeartItem = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(0, 8, 7, 7) ,
                        new Rectangle(0, 0, 7, 7)},new Vector2(3.5f,3.5f));

    }


    public void Draw(SpriteBatch spriteBatch)
    {
        HeartItem.SetPosition(itemPosition);


        HeartItem.Draw(spriteBatch);
    }
    
    public void Update(GameTime gameTime)
    {
        HeartItem.Update(gameTime);
    }


}