using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace SuperMario
{
    public static class SoundManager
    {
        private enum SoundPlayMode
        {
            Default,
            Eager,
            Lazy
        }

        private enum CurrentlyPlayingMusic
        {
            Overworld,
            Harp
        }

        private static CurrentlyPlayingMusic cpm = CurrentlyPlayingMusic.Overworld;

        // Background Musics
        private static SoundEffect overworldMusic;
        private static SoundEffect underworldMusic;
        private static SoundEffect dieMusic;
        private static SoundEffect winMusic;
        private static SoundEffect starMusic;
        private static SoundEffect harpMusic;

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
        private static SoundEffect fireballSound;
        private static SoundEffect oneupSound;
        private static SoundEffect flagpoleSound;
        private static SoundEffect superfireSound;
        private static SoundEffect fireworkSound;

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
        private static SoundEffectInstance fireballInstance;
        private static SoundEffectInstance oneupInstance;
        private static SoundEffectInstance flagpoleInstance;
        private static SoundEffectInstance superfireInstance;
        private static SoundEffectInstance fireworkInstance;

        // Sound Properties
        private static SoundEffectInstance SmallJumpSound
        {
            get { return CreateInstance(smallJumpSound, ref smallJumpInstance, SoundPlayMode.Lazy); }
        }

        private static SoundEffectInstance SuperJumpSound
        {
            get { return CreateInstance(superJumpSound, ref superJumpInstance, SoundPlayMode.Lazy); }
        }

        private static SoundEffectInstance BumpSound
        {
            get { return CreateInstance(bumpSound, ref bumpInstance, SoundPlayMode.Lazy); }
        }

        private static SoundEffectInstance BlockBreakSound
        {
            get { return CreateInstance(blockBreakSound, ref blockBreakInstance, SoundPlayMode.Lazy); }
        }

        private static SoundEffectInstance StompSound
        {
            get { return CreateInstance(stompSound, ref stompInstance, SoundPlayMode.Lazy); }
        }

        private static SoundEffectInstance CoinSound
        {
            get { return CreateInstance(coinSound, ref coinInstance, SoundPlayMode.Lazy); }
        }

        private static SoundEffectInstance PowerUpAppearSound
        {
            get { return CreateInstance(powerUpAppearSound, ref powerUpAppearInstance, SoundPlayMode.Lazy); }
        }

        private static SoundEffectInstance PowerUpSound
        {
            get { return CreateInstance(powerUpSound, ref powerUpInstance, SoundPlayMode.Lazy); }
        }

        private static SoundEffectInstance KickSound
        {
            get { return CreateInstance(kickSound, ref kickInstance, SoundPlayMode.Lazy); }
        }

        private static SoundEffectInstance PipeSound
        {
            get { return CreateInstance(pipeSound, ref pipeInstance, SoundPlayMode.Lazy); }
        }

        private static SoundEffectInstance FireballSound
        {
            get { return CreateInstance(fireballSound, ref fireballInstance, SoundPlayMode.Eager); }
        }

        private static SoundEffectInstance OneUpSound
        {
            get { return CreateInstance(oneupSound, ref oneupInstance, SoundPlayMode.Lazy); }
        }

        private static SoundEffectInstance FlagPoleSound
        {
            get { return CreateInstance(flagpoleSound, ref flagpoleInstance, SoundPlayMode.Lazy); }
        }

        private static SoundEffectInstance SuperFireSound
        {
            get { return CreateInstance(superfireSound, ref superfireInstance, SoundPlayMode.Eager); }
        }

        private static SoundEffectInstance FireWorkSound
        {
            get { return CreateInstance(fireworkSound, ref fireworkInstance, SoundPlayMode.Default); }
        }

        private static SoundEffectInstance CreateInstance(SoundEffect soundEffect, ref SoundEffectInstance soundInstance, SoundPlayMode mode)
        {
            switch (mode)
            {
                case SoundPlayMode.Default:
                    return soundEffect.CreateInstance();
                case SoundPlayMode.Eager:
                    soundInstance = soundEffect.CreateInstance();
                    return soundInstance;
                case SoundPlayMode.Lazy:
                    if (soundInstance != null && soundInstance.State == SoundState.Playing) return null;
                    soundInstance = soundEffect.CreateInstance();
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
            harpMusic = content.Load<SoundEffect>("Audio/harp");

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
            fireballSound = content.Load<SoundEffect>("Audio/fireball");
            oneupSound = content.Load<SoundEffect>("Audio/smb_1-up");
            flagpoleSound = content.Load<SoundEffect>("Audio/smb_flagpole");
            superfireSound = content.Load<SoundEffect>("Audio/smb_bowserfire");
            fireworkSound = content.Load<SoundEffect>("Audio/fireworks");
            harpMusic = content.Load<SoundEffect>("Audio/harp");

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
            if (cpm != CurrentlyPlayingMusic.Overworld)
            {
                if (currentBackgroundMusic != null)
                {
                    currentBackgroundMusic.Dispose();
                }
                currentBackgroundMusic = underworldMusic.CreateInstance();
                currentBackgroundMusic.IsLooped = true;
                currentBackgroundMusic.Play();

                cpm = CurrentlyPlayingMusic.Overworld;
            }
            
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

        public static void ChangeToHarpMusic()
        {
            if (cpm != CurrentlyPlayingMusic.Harp) {
                if (currentBackgroundMusic != null)
                {
                    currentBackgroundMusic.Dispose();
                }
                currentBackgroundMusic = harpMusic.CreateInstance();
                currentBackgroundMusic.IsLooped = true;
                currentBackgroundMusic.Play();

                cpm = CurrentlyPlayingMusic.Harp;
            }
        }


        public static void PauseMusic()
        {
            if (currentBackgroundMusic != null)
            {
                currentBackgroundMusic.Dispose();
            }
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

        public static void FireballSoundPlay()
        {
            PlaySound(FireballSound);
        }

        public static void OneUpSoundPlay()
        {
            PlaySound(OneUpSound);
        }

        public static void FlagpoleSoundPlay()
        {
            PlaySound(FlagPoleSound);
        }

        public static void SuperFireSoundPlay()
        {
            PlaySound(SuperFireSound);
        }

        public static void FireworkSoundPlay()
        {
            var sound = FireWorkSound;
            sound.Volume = 1;
            PlaySound(sound);
        }
    }
}