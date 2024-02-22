using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace cse3902;

public class MapItemPickup : IItemPickup
{
    private Sprite MapSprite;
    private Vector2 itemPosition = new Vector2(300, 200); // Example positions

    public MapItemPickup(GameContent content)
    {
        MapSprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(87, 0, 8, 15) });
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        MapSprite.SetPosition(itemPosition);

        MapSprite.Draw(spriteBatch);
    }
    
    public void Update(GameTime gameTime)
    {
    }


}