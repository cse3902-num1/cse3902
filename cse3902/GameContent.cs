using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace cse3902
{
    public class GameContent
    {
        public Texture2D LinkSpritesheet;
        public Texture2D NewLinkSpritesheet;
        public GameContent(ContentManager content) 
        {
            LinkSpritesheet = content.Load<Texture2D>("spritesheet_link");
            NewLinkSpritesheet = content.Load<Texture2D>("spritesheet");
        }
    }
}
