﻿using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public static class SoundManager
    {
        // Background Musics
        private static SoundEffect overworldMusic;
        private static SoundEffect underworldMusic;
        private static SoundEffect dieMusic;
        private static SoundEffect winMusic;
        private static SoundEffect starMusic;

        // Action Sounds
        private static SoundEffect smallJumpSound;
        private static SoundEffect superJumpSound;
        private static SoundEffect bumpSound;
        private static SoundEffect blockBreakSound;
        private static SoundEffect stompSound;
        private static SoundEffect coinSound;
        private static SoundEffect powerUpAppearSound;
        private static SoundEffect powerUpSound;
        private static SoundEffect kickSound;
        private static SoundEffect pipeSound;

        // Music Instance
        private static SoundEffectInstance currentBackgroundMusic;

        // Sound Instances
        private static SoundEffectInstance smallJumpInstance;
        private static SoundEffectInstance superJumpInstance;
        private static SoundEffectInstance bumpInstance;
        private static SoundEffectInstance blockBreakInstance;
        private static SoundEffectInstance stompInstance;
        private static SoundEffectInstance coinInstance;
        private static SoundEffectInstance powerUpAppearInstance;
        private static SoundEffectInstance powerUpInstance;
        private static SoundEffectInstance kickInstance;
        private static SoundEffectInstance pipeInstance;

        // Sound Properties
        private static SoundEffectInstance SmallJumpSound
        {
            get { return CreateInstance(smallJumpSound, ref smallJumpInstance); }
        }

        private static SoundEffectInstance SuperJumpSound
        {
            get { return CreateInstance(superJumpSound, ref superJumpInstance); }
        }

        private static SoundEffectInstance BumpSound
        {
            get { return CreateInstance(bumpSound, ref bumpInstance); }
        }

        private static SoundEffectInstance BlockBreakSound
        {
            get { return CreateInstance(blockBreakSound, ref blockBreakInstance); }
        }

        private static SoundEffectInstance StompSound
        {
            get { return CreateInstance(stompSound, ref stompInstance); }
        }

        private static SoundEffectInstance CoinSound
        {
            get { return CreateInstance(coinSound, ref coinInstance); }
        }

        private static SoundEffectInstance PowerUpAppearSound
        {
            get { return CreateInstance(powerUpAppearSound, ref powerUpAppearInstance); }
        }

        private static SoundEffectInstance PowerUpSound
        {
            get { return CreateInstance(powerUpSound, ref powerUpInstance); }
        }

        private static SoundEffectInstance KickSound
        {
            get { return CreateInstance(kickSound, ref kickInstance); }
        }

        private static SoundEffectInstance PipeSound
        {
            get { return CreateInstance(pipeSound, ref pipeInstance); }
        }

        private static SoundEffectInstance CreateInstance(SoundEffect soundEffect, ref SoundEffectInstance soundInstance)
        {
            if (soundInstance == null || soundInstance.State == SoundState.Stopped)
            {
                soundInstance = soundEffect.CreateInstance();
                soundInstance.IsLooped = false;
                return soundInstance;
            }
            return null;
        }

        private static void PlaySound(SoundEffectInstance sound)
        {
            if (sound != null) sound.Play();
        }

        public static void LoadAllSounds(ContentManager content)
        {
            overworldMusic = content.Load<SoundEffect>("Audio/overworld");
            underworldMusic = content.Load<SoundEffect>("Audio/underworld");
            dieMusic = content.Load<SoundEffect>("Audio/die");
            winMusic = content.Load<SoundEffect>("Audio/win");
            starMusic = content.Load<SoundEffect>("Audio/star");
            smallJumpSound = content.Load<SoundEffect>("Audio/jump-small");
            superJumpSound = content.Load<SoundEffect>("Audio/jump-super");
            bumpSound = content.Load<SoundEffect>("Audio/bump");
            blockBreakSound = content.Load<SoundEffect>("Audio/blockBreak");
            stompSound = content.Load<SoundEffect>("Audio/stomp");
            coinSound = content.Load<SoundEffect>("Audio/coin");
            powerUpAppearSound = content.Load<SoundEffect>("Audio/powerUpAppear");
            powerUpSound = content.Load<SoundEffect>("Audio/powerUp");
            kickSound = content.Load<SoundEffect>("Audio/kick");
            pipeSound = content.Load<SoundEffect>("Audio/pipe");
        }

        public static void StopMusic()
        {
            currentBackgroundMusic.Dispose();
        }

        public static void ChangeToOverworldMusic()
        {
            if (currentBackgroundMusic != null)
            {
                currentBackgroundMusic.Dispose();
            }
            currentBackgroundMusic = overworldMusic.CreateInstance();
            currentBackgroundMusic.IsLooped = true;
            currentBackgroundMusic.Play();
        }

        public static void ChangeToUnderworldMusic()
        {
            if (currentBackgroundMusic != null)
            {
                currentBackgroundMusic.Dispose();
            }
            currentBackgroundMusic = underworldMusic.CreateInstance();
            currentBackgroundMusic.IsLooped = true;
            currentBackgroundMusic.Play();
        }

        public static void ChangeToDieMusic()
        {
            if (currentBackgroundMusic != null)
            {
                currentBackgroundMusic.Dispose();
            }
            currentBackgroundMusic = dieMusic.CreateInstance();
            currentBackgroundMusic.IsLooped = false;
            currentBackgroundMusic.Play();
            DieMusicPlaying = true;
        }

        public static bool DieMusicPlaying { get; private set; }

        public static bool DieMusicFinished
        {
            get
            {
                if (DieMusicPlaying && currentBackgroundMusic.State == SoundState.Stopped)
                {
                    DieMusicPlaying = false;
                    return true;
                }
                return false;
            }
        }

        public static void ChangeToWinMusic()
        {
            if (currentBackgroundMusic != null)
            {
                currentBackgroundMusic.Dispose();
            }
            currentBackgroundMusic = winMusic.CreateInstance();
            currentBackgroundMusic.IsLooped = false;
            currentBackgroundMusic.Play();
        }

        public static void ChangeToStarMusic()
        {
            if (currentBackgroundMusic != null)
            {
                currentBackgroundMusic.Dispose();
            }
            currentBackgroundMusic = starMusic.CreateInstance();
            currentBackgroundMusic.IsLooped = true;
            currentBackgroundMusic.Play();
        }

        public static void SmallJumpSoundPlay()
        {
            PlaySound(SmallJumpSound);
        }

        public static void SuperJumpSoundPlay()
        {
            PlaySound(SuperJumpSound);
        }

        public static void BumpSoundPlay()
        {
            if (smallJumpInstance != null && smallJumpInstance.State == SoundState.Playing) 
                smallJumpInstance.Stop();
            if (superJumpInstance != null && superJumpInstance.State == SoundState.Playing) 
                superJumpInstance.Stop();
            PlaySound(BumpSound);
        }

        public static void BlockBreakSoundPlay()
        {
            PlaySound(BlockBreakSound);
        }

        public static void StompSoundPlay()
        {
            PlaySound(StompSound);
        }

        public static void CoinSoundPlay()
        {
            PlaySound(CoinSound);
        }

        public static void PowerUpAppearSoundPlay()
        {
            PlaySound(PowerUpAppearSound);
        }

        public static void PowerUpSoundPlay()
        {
            PlaySound(PowerUpSound);
        }

        public static void PowerDownSoundPlay()
        {
            PipeSoundPlay();
        }

        public static void KickSoundPlay()
        {
            PlaySound(KickSound);
        }

        public static void PipeSoundPlay()
        {
            PlaySound(PipeSound);
        }
    }
}