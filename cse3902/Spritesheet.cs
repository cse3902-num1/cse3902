using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace cse3902
{
    public class Spritesheet
    {
        public Texture2D ContentSpritesheetLink;
        public Spritesheet(ContentManager content) 
        {
            ContentSpritesheetLink = content.Load<Texture2D>("spritesheet_link");
            ContentSpritesheetLink = content.Load<Texture2D>("spritesheet")
        }

    }
}

