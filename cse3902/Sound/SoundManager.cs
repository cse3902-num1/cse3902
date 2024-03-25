using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace cse3902
{
    class SoundManager
    {
        private static SoundManager manager = null;

        public static SoundManager Manager
        {
            get
            {
                if (manager == null)
                {
                    manager = new SoundManager();
                }
                return manager;
            }
        }

        private static Song music = null;
        private static SoundEffect sword = null;
        private static SoundEffect itemPickUp = null;
        private static SoundEffect linkDamage = null;
        private static SoundEffect linkDead = null;
        private static SoundEffect enemyDamage = null;
        private static SoundEffect enemyDead = null;
        private static SoundEffect arrowBoomerang = null;
        private static SoundEffect bombDrop = null;
        private static SoundEffect bombBlowUp = null;
  
        private static SoundEffect fireball = null;
        public static SoundEffectInstance musicLoop = null;


        private SoundManager() { }

        public void LoadContent(GameContent content)
        {
            music = content.bgmusic;
            sword = content.sword;
            itemPickUp = content.itemPickUp;
            linkDamage = content.linkDamage;
            linkDead = content.linkDead;
            enemyDamage = content.enemyDamage;
            enemyDead = content.enemyDead;
            arrowBoomerang = content.arrowBoomerang;
            bombDrop = content.bombDrop;
            bombBlowUp = content.bombBlowUp;
            fireball = content.fireball;

            MediaPlayer.Volume = 0.2f;
            MediaPlayer.Play(music);
            MediaPlayer.IsRepeating = true;
        }

        public SoundEffect swordSound()
        {
            return sword;
        }
        public SoundEffect itemPickUpSound()
        {
            return itemPickUp;
        }
        public SoundEffect linkDamageSound()
        {
            return linkDamage;
        }
        public SoundEffect linkDeadSound()
        {
            return linkDead;
        }
        public SoundEffect enemyDamageSound()
        {
            return enemyDamage;
        }
        public SoundEffect enemyDeadSound()
        {
            return enemyDead;
        }
        public SoundEffect arrowBoomerangSound()
        {
            return arrowBoomerang;
        }
        public SoundEffect bombDropSound()
        {
            return bombDrop;
        }
        public SoundEffect bombBlowUpSound()
        {
            return bombBlowUp;
        }

        public SoundEffect fireballSound()
        {
            return fireball;
        }
    }
}