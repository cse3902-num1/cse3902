using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using cse3902.Interfaces;
using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using cse3902.WallClasses;


namespace cse3902.PlayerClasses
{    
    public class Player : IPlayer
    {
        public Room CurrentRoom {set;get;}

        public PlayerInventory Inventory {set;get;}
        
        public Stopwatch damageTimer;

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
        public int health = 5;
        public GameContent content;
        public Player(GameContent content)
        {
            damageTimer = new Stopwatch();
            this.content = content;
            State = new PlayerStateIdle(content,this);
            
            Pushbox = new BoxCollider(Position,Size*3, Origin*3, ColliderType.PLAYER);

            Inventory = new PlayerInventory();
        }

        public void Update(GameTime gameTime, List<IController> controllers)
        {
            if (controllers.Any(c => c.isPlayerTakeDamageJustPressed()))
            {
                TakeDamage();
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
            bool istrue = this.State is PlayerDamage;
            Debug.WriteLine(istrue);
            if (!(istrue))
            {
                Debug.WriteLine("entering damage state");
                State = new PlayerDamage(content, this);
            }
            if (health > 0)
            {
                health -= 1;

                Debug.WriteLine("player health is: " + health);
            }
            if (health == 0)
            {
                Debug.WriteLine("YOU ARE DEAD!!!!!");
                EventBus.PlayerDying(this);
            }
            
        }
    }
}
