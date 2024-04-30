using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
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
        private bool isMusicPaused = false;

        private static Song music = null;
        private static Song BossMusic =null;
        private static Song MenuMusic = null;
        private static SoundEffect sword = null;
        private static SoundEffect itemPickUp = null;
        private static SoundEffect linkDamage = null;
        private static SoundEffect linkDead = null;
        private static SoundEffect enemyDamage = null;
        private static SoundEffect enemyDead = null;
        private static SoundEffect arrowBoomerang = null;
        private static SoundEffect bombDrop = null;
        private static SoundEffect bombBlowUp = null;
        private static SoundEffect gameOver = null;
        private static SoundEffect victory = null;

        //private static SoundEffect fireball = null;
        private static SoundEffect newFireball = null;
        public static SoundEffectInstance musicLoop = null;


        private SoundManager() { }

        public void LoadContent(GameContent content)
        {
            music = content.bgmusic;
            BossMusic = content.BossMusic;
            MenuMusic = content.MenuMusic;
            sword = content.sword;
            itemPickUp = content.itemPickUp;
            linkDamage = content.linkDamage;
            linkDead = content.linkDead;
            enemyDamage = content.enemyDamage;
            enemyDead = content.enemyDead;
            arrowBoomerang = content.arrowBoomerang;
            bombDrop = content.bombDrop;
            bombBlowUp = content.bombBlowUp;
            //fireball = content.fireball;
            newFireball = content.newFireball;
            gameOver = content.GameOver;
            victory = content.Victory;
            
        }
        public void Update(GameTime gameTime, List<IController> controllers) {


            if (controllers.Any(c => c.isMutePressed()) == true)
            {
                if (isMusicPaused)
                {
                    MediaPlayer.Resume();
                    isMusicPaused = false;
                }
                else
                {
                    MediaPlayer.Pause();
                    isMusicPaused = true;
                }
            }

        }
        public void CommonBGM()
        {
            MediaPlayer.Volume = 0.2f;
            MediaPlayer.Play(music);
            MediaPlayer.IsRepeating = true;

        }
        public void BossBGM(){
            
                MediaPlayer.Volume = 0.05f;
                MediaPlayer.Play(BossMusic);
                MediaPlayer.IsRepeating = true;
            
        }
        public void MenuBGM()
        {

            MediaPlayer.Volume = 0.3f;
            MediaPlayer.Play(MenuMusic);
            MediaPlayer.IsRepeating = true;

        }
        public void swordSound()
        {
            if (!isMusicPaused)
            {
                sword.Play();
            }
        }
        public void itemPickUpSound()
        {
            if (!isMusicPaused)
            {
                itemPickUp.Play();
            }
        }
        public void linkDamageSound()
        {
            if (!isMusicPaused)
            {
                linkDamage.Play();
            }
        }
        public void linkDeadSound()
        {
            if (!isMusicPaused)
            {
                linkDead.Play();
            }
        }
        public void enemyDamageSound()
        {
            if (!isMusicPaused)
            {
                enemyDamage.Play();
            }
        }
        public void enemyDeadSound()
        {
            if (!isMusicPaused)
            {
                enemyDead.Play();
            }
        }
        public void arrowBoomerangSound()
        {
            if (!isMusicPaused)
            {
                arrowBoomerang.Play();
            }
        }
        public void bombDropSound()
        {
            if (!isMusicPaused)
            {
                bombDrop.Play();
            }
        }
        public void bombBlowUpSound()
        {
            if (!isMusicPaused)
            {
                bombBlowUp.Play();
            }
        }

       /* public void fireballSound()
        {
            if (!isMusicPaused)
            {
                fireball.Play();
            }
        }
       */
        public void newFireballSound()
        {
            if (!isMusicPaused)
            {
                newFireball.Play();
            }
        }
        public void GameOver()
        {
            if (!isMusicPaused)
            {
               gameOver.Play();
            }
        }
        public void Victory()
        {
            if (!isMusicPaused)
            {
                victory.Play();
            }
        }
    }
}