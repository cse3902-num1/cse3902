using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace cse3902;

public class MagicalKeyItemPickup : IItemPickup
{
    private Sprite MagicalKeySprite;
    private Vector2 itemPosition = new Vector2(300, 200); // Example positions

    public MagicalKeyItemPickup(GameContent content)
    {
        MagicalKeySprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(248, 0, 8, 16)});
    }


    public void Draw(SpriteBatch spriteBatch)
    {

        MagicalKeySprite.SetPosition(itemPosition);

        MagicalKeySprite.Draw(spriteBatch);
    }
    
    public void Update(GameTime gameTime)
    {
    }


}