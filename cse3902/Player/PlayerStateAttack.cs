using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902
{
    public class PlayerStateAttack : IPlayerState
    {
        private Player player;
        private ISprite attackSprite = new Sprite();
        public PlayerStateAttack(Player player)
        {
            this.player = player;
            // TODO: set texture and frame data of attackSprite
        }

        public void Update(GameTime gameTime)
        {
            // TODO: return to idle state if attackSprite animation is done
            attackSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            attackSprite.Draw(spriteBatch);
        }
    }
}
