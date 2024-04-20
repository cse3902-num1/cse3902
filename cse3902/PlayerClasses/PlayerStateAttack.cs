using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902.PlayerClasses
{
    public class PlayerStateAttack : IPlayerState
    {
        private Player player;
        private Dictionary<Direction, Sprite> sprites;
        private GameContent content;
        private Vector2 playerAttackLeftOrigin = new Vector2(18, 8);
        private Vector2 playerAttackRightOrigin = new Vector2(18, 8);
        private Vector2 playerAttackUpOrigin = new Vector2(18, 8);
        private Vector2 playerAttackDownOrigin = new Vector2(18, 8);

        public PlayerStateAttack(GameContent content, Player player)
        {
            this.content = content;
            this.player = player;

            sprites = new Dictionary<Direction, Sprite>() {
                {Direction.Left, new Sprite(content.SpritesheetLinkAttackWoodSword, new List<Rectangle>() {
                    PlayerConstant.PlayerAttackingLeftAnimation1,
                    PlayerConstant.PlayerAttackingLeftAnimation2,
                    PlayerConstant.PlayerAttackingLeftAnimation3,
                    PlayerConstant.PlayerAttackingLeftAnimation4,
                }, playerAttackLeftOrigin)},

                {Direction.Right, new Sprite(content.SpritesheetLinkAttackWoodSword, new List<Rectangle>() {
                    PlayerConstant.PlayerAttackingRightAnimation1,
                    PlayerConstant.PlayerAttackingRightAnimation2,
                    PlayerConstant.PlayerAttackingRightAnimation3,
                    PlayerConstant.PlayerAttackingRightAnimation4,
                }, playerAttackRightOrigin)},

                {Direction.Up, new Sprite(content.SpritesheetLinkAttackWoodSword, new List<Rectangle>() {
                    PlayerConstant.PlayerAttackingUpAnimation1,
                    PlayerConstant.PlayerAttackingUpAnimation2,
                    PlayerConstant.PlayerAttackingUpAnimation3,
                    PlayerConstant.PlayerAttackingUpAnimation4,
                }, playerAttackUpOrigin)},

                {Direction.Down, new Sprite(content.SpritesheetLinkAttackWoodSword, new List<Rectangle>() {
                    PlayerConstant.PlayerAttackingDownAnimation1,
                    PlayerConstant.PlayerAttackingDownAnimation2,
                    PlayerConstant.PlayerAttackingDownAnimation3,
                    PlayerConstant.PlayerAttackingDownAnimation4,
                }, playerAttackDownOrigin)}
            };
        }

        public void Update(GameTime gameTime, List<IController> controllers)
        {
            /* go to idle state if attack animation is done */
            if (sprites[player.Facing].IsAnimationDone())
            {
                player.State = new PlayerStateIdle(content, player);
            }




            sprites[player.Facing].Update(gameTime, controllers);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprites[player.Facing].SetPosition(player.Position.X, player.Position.Y);
            sprites[player.Facing].Draw(spriteBatch);
             
        }
    }
}