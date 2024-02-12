using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902
{
    public class Level
    {
        private Player player;
        private List<IEnemy> enemies;

        public Level(GameContent content)
        {
            player = new Player(content);
            /* TODO: set starting position of player */

            /* TODO: create enemies */

            /* TODO: create block */

            /* TODO: create items */
        }

        public void Update(GameTime gameTime, IController controller)
        {
            player.Update(gameTime, controller);

            /* TODO: update other stuff */
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            player.Draw(spriteBatch);

            /* TODO: update other stuff */
        }
    }
}
