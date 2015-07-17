using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public static class SoundManager
    {
        private static SoundEffectInstance currentlyPlayingMusic;

        private static SoundEffect overworldMusic;
        private static SoundEffect underworldMusic;
        private static SoundEffect dieMusic;
        private static SoundEffect winMusic;
        private static SoundEffect starMusic;

        private static SoundEffect jumpSound;
        private static SoundEffect blockBreakSound;
        private static SoundEffect stompSound;
        private static SoundEffect coinSound;
        private static SoundEffect powerUpAppearSound;
        private static SoundEffect powerUpSound;
        private static SoundEffect kickSound;
        private static SoundEffect pipeSound;


        public static void LoadAllSounds(ContentManager content)
        {
            overworldMusic = content.Load<SoundEffect>("Audio/overworld");
            underworldMusic = content.Load<SoundEffect>("Audio/underworld");
            dieMusic = content.Load<SoundEffect>("Audio/die");
            winMusic = content.Load<SoundEffect>("Audio/win");
            starMusic = content.Load<SoundEffect>("Audio/star");

            jumpSound = content.Load<SoundEffect>("Audio/jump");
            blockBreakSound = content.Load<SoundEffect>("Audio/blockBreak");
            stompSound = content.Load<SoundEffect>("Audio/stomp");
            coinSound = content.Load<SoundEffect>("Audio/coin");
            powerUpAppearSound = content.Load<SoundEffect>("Audio/powerUpAppear");
            powerUpSound = content.Load<SoundEffect>("Audio/powerUp");
            kickSound = content.Load<SoundEffect>("Audio/kick");
            pipeSound = content.Load<SoundEffect>("Audio/pipe");
        }

        public static void stopMusic()
        {
            currentlyPlayingMusic.Dispose();
        }

        public static void changeToOverworldMusic()
        {
            if (currentlyPlayingMusic != null)
            {
                currentlyPlayingMusic.Dispose();
            }
            currentlyPlayingMusic = overworldMusic.CreateInstance();
            currentlyPlayingMusic.IsLooped = true;
            currentlyPlayingMusic.Play();
        }

        public static void changeToUnderworldMusic()
        {
            if (currentlyPlayingMusic != null)
            {
                currentlyPlayingMusic.Dispose();
            }
            currentlyPlayingMusic.Dispose();
            currentlyPlayingMusic = underworldMusic.CreateInstance();
            currentlyPlayingMusic.IsLooped = true;
            currentlyPlayingMusic.Play();
        }

        public static void changeToDieMusic()
        {
            if (currentlyPlayingMusic != null)
            {
                currentlyPlayingMusic.Dispose();
            }
            currentlyPlayingMusic = dieMusic.CreateInstance();
            currentlyPlayingMusic.IsLooped = false;
            currentlyPlayingMusic.Play();
        }

        public static void changeToWinMusic()
        {
            if (currentlyPlayingMusic != null)
            {
                currentlyPlayingMusic.Dispose();
            }
            currentlyPlayingMusic = winMusic.CreateInstance();
            currentlyPlayingMusic.IsLooped = false;
            currentlyPlayingMusic.Play();
        }

        public static void changeToStarMusic()
        {
            if (currentlyPlayingMusic != null)
            {
                currentlyPlayingMusic.Dispose();
            }
            currentlyPlayingMusic = starMusic.CreateInstance();
            currentlyPlayingMusic.IsLooped = true;
            currentlyPlayingMusic.Play();
        }

        public static void jumpSoundPlay()
        {
            jumpSound.Play();
        }

        public static void blockBreakSoundPlay()
        {
            blockBreakSound.Play();
        }

        public static void stompSoundPlay()
        {
            stompSound.Play();
        }

        public static void coinSoundPlay()
        {
            coinSound.Play();
        }

        public static void powerUpAppearSoundPlay()
        {
            powerUpAppearSound.Play();
        }

        public static void powerUpSoundPlay()
        {
            powerUpSound.Play();
        }

        public static void kickSoundPlay()
        {
            kickSound.Play();
        }

        public static void pipeSoundPlay()
        {
            pipeSound.Play();
        }
    }
}