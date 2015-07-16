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
        private static SoundEffect jumpSound;
        private static SoundEffect blockBreakSound;
        private static SoundEffect stompSound;
        private static SoundEffect coinSound;
        private static SoundEffect powerUpAppearSound;
        private static SoundEffect powerUpSound;
        private static SoundEffect kickSound;


        public static void LoadAllSounds(ContentManager content)
        {
            overworldMusic = content.Load<SoundEffect>("Audio/overworldMusic");
            jumpSound = content.Load<SoundEffect>("Audio/jump");
            blockBreakSound = content.Load<SoundEffect>("Audio/blockBreak");
            stompSound = content.Load<SoundEffect>("Audio/stomp");
            coinSound = content.Load<SoundEffect>("Audio/coin");
            powerUpAppearSound = content.Load<SoundEffect>("Audio/powerUpAppear");
            powerUpSound = content.Load<SoundEffect>("Audio/powerUp");
            kickSound = content.Load<SoundEffect>("Audio/kick");
        }

        public static void OverworldMusicPlay()
        {
            currentlyPlayingMusic = overworldMusic.CreateInstance();
            currentlyPlayingMusic.IsLooped = true;
            currentlyPlayingMusic.Play();
        }

        public static void JumpSoundPlay()
        {
            jumpSound.Play();
        }

        public static void BlockBreakSoundPlay()
        {
            blockBreakSound.Play();
        }

        public static void StompSoundPlay()
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
    }
}