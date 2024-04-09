using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using cse3902.Interfaces;
using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using cse3902.WallClasses;
using Microsoft.Xna.Framework.Audio;


namespace cse3902.PlayerClasses
{    
    public class Player : IPlayer
    {
        public Room CurrentRoom {set;get;}

        public PlayerInventory Inventory {set;get;}
        
        public Stopwatch damageTimer;
        private bool isDamaged = false;
        private const int RandomChangeInterval = 500;

        private Vector2 _position = Vector2.Zero;
        public Vector2 Position {
            set {
                _position = value;
                Pushbox.Position = value;
            }
            get {
                return _position;
            }
        }
        public Direction Facing {set;get;}
        public Vector2 Origin { set;get;} = new Vector2(8,8);
        public Vector2 Size { set;get;} = new Vector2(16,16);
        public ICollider Pushbox {set;get;}
        public IPlayerState State;
        
        public GameContent content;
        public Player(GameContent content)
        {
            damageTimer = new Stopwatch();
            this.content = content;
            State = new PlayerStateIdle(content,this);
            
            Pushbox = new BoxCollider(Position,Size*2.5f, Origin*2.5f, ColliderType.PLAYER);

            Inventory = new PlayerInventory();
        }

        public void Update(GameTime gameTime, List<IController> controllers)
        {
            if (controllers.Any(c => c.isPlayerTakeDamageJustPressed()))
            {
                TakeDamage();
            }
            if (isDamaged && damageTimer.ElapsedMilliseconds >= 500)
            {
                isDamaged = false;  // Reset damage flag after cooldown
            }

            State.Update(gameTime, controllers);

            Pushbox.Position = Position;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //sprite.Draw(spriteBatch);
            State.Draw(spriteBatch);
            
        }

        public void Move(Vector2 direction)
        {
            throw new NotImplementedException();
        }

        public void Attack()
        {
            throw new NotImplementedException();
        }

        /* Sets the current item, which is used by PlayerStateItem. */
        public void UseItem(IInventoryItem item)
        {
            item.Use(this, CurrentRoom);
        }

        public void TakeDamage()
        {
            if (!(State is PlayerDamage))
            {
                State = new PlayerDamage(content, this);
                Debug.WriteLine("current state is: " + State);
                Debug.WriteLine(Inventory.health);
            }
           
            if (Inventory.health > 0)
            {
                if (!isDamaged)
                {
                    SoundManager.Manager.linkDamageSound();
                    Inventory.health -= 1;
                    isDamaged = true;
                    damageTimer.Restart();  // Restart the stopwatch when damage is taken
                }

                if (damageTimer.ElapsedMilliseconds >= RandomChangeInterval)
                {
                    isDamaged = false; // Reset damage flag after 100 ms
                }
            }
            if (Inventory.health == 0)
            {
                Debug.WriteLine("YOU ARE DEAD!!!!!");
                EventBus.PlayerDying(this);
            }
            
        }
    }
}
