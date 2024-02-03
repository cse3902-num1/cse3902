using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902
{
    public class PlayerStateIdle : IPlayerState
    {
        private Player player;
        private ISprite idleSprite = new Sprite();

        public PlayerStateIdle(Player player)
        {
            this.player = player;
            // TODO: set texture and frame data of idleSprite
        }

        public void Update(GameTime gameTime)
        {
            /* play idle sprite animation */
            idleSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            idleSprite.Position = player.Position;
            idleSprite.Draw(spriteBatch);
        }
    }
}
