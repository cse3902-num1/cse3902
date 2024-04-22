using System;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902.RoomClasses
{
	public class Minimap
	{

        private const int MINIMAP_WIDTH = 64;
        private const int MINIMAP_HEIGHT = 44;
        private const float MINIMAP_SCALE_FACTOR = 0.25f;
        private Texture2D minimapTexture;
        GameContent content;

        public Minimap(GameContent content)
		{

            minimapTexture = content.hud;
           
        }


	}
}

