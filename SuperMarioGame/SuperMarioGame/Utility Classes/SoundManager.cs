using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace SuperMario
{
    public static class SoundManager
    {
        private const string AudioDirectory = "Audio/";

        private enum SoundPlayMode
        {
            Default,
            Eager,
            Lazy
        }

        private class SoundData
        {
            public SoundEffect Source;
            public SoundEffectInstance Instance;
            public SoundPlayMode Mode;
        }

        private enum SoundType
        {
            SmallJump,
            SuperJump,
            Bump,
            BlockBreak,
            Stomp,
            Coin,
            ItemAppear,
            PowerUp,
            Kick,
            Pipe,
            NormalFire,
            SuperFire,
            OneUp,
            FlagPole,
            Firework
        }

        private enum MusicType
        {
            Overworld,
            Underworld,
            Fail,
            Win,
            StarPower,
            Harp
        }

        private static MusicType ActiveMusic { get; set; }

        private static MusicType LastMusic { get; set; }

        private static Dictionary<SoundType, SoundData> SoundList { get; set; }

        private static Dictionary<MusicType, SoundEffectInstance> MusicList { get; set; }

        private static void RegisterSound(ContentManager content, SoundType type, string fileName, SoundPlayMode mode)
        {
            var source = content.Load<SoundEffect>(AudioDirectory + fileName);
            SoundList.Add(type, new SoundData
            {
                Source = source,
                Instance = source.CreateInstance(),
                Mode = mode
            });
        }

        private static void RegisterMusic(ContentManager content, MusicType type, string fileName, bool loop)
        {
            var instance = content.Load<SoundEffect>(AudioDirectory + fileName).CreateInstance();
            instance.IsLooped = loop;
            MusicList.Add(type, instance);
        }

        private static void PlaySound(SoundType type)
        {
            var sound = SoundList[type];
            switch (sound.Mode)
            {
                case SoundPlayMode.Default:
                    sound.Source.CreateInstance().Play();
                    return;
                case SoundPlayMode.Eager:
                    sound.Instance = sound.Source.CreateInstance();
                    sound.Instance.Play();
                    return;
                case SoundPlayMode.Lazy:
                    if (CheckState(type) == SoundState.Playing) return;
                    sound.Instance = sound.Source.CreateInstance();
                    sound.Instance.Play();
                    return;
            }
        }

        private static void StopSound(SoundType type)
        {
            SoundList[type].Instance.Stop();
        }

        private static void PauseSound(SoundType type)
        {
            SoundList[type].Instance.Pause();
        }

        private static SoundState CheckState(SoundType type)
        {
            return SoundList[type].Instance.State;
        }

        private static void PauseAllMusic()
        {
            foreach (var music in MusicList)
            {
                music.Value.Pause();
            }
        }

        private static void PlayMusic(MusicType type, bool restart = true)
        {
            if (ActiveMusic == type && CheckState(type) == SoundState.Playing) return;
            LastMusic = ActiveMusic;
            ActiveMusic = type;
            PauseAllMusic();
            if (restart) MusicList[type].Stop();
            MusicList[type].Play();
        }

        private static SoundState CheckState(MusicType type)
        {
            return MusicList[type].State;
        }

        public static void LoadAllSounds(ContentManager content)
        {
            SoundList = new Dictionary<SoundType, SoundData>();
            MusicList = new Dictionary<MusicType, SoundEffectInstance>();

            RegisterMusic(content, MusicType.Overworld, "overworld", true);
            RegisterMusic(content, MusicType.Underworld, "underworld", true);
            RegisterMusic(content, MusicType.Fail, "die", false);
            RegisterMusic(content, MusicType.Win, "win", false);
            RegisterMusic(content, MusicType.StarPower, "star", true);
            RegisterMusic(content, MusicType.Harp, "harp", true);
            
            RegisterSound(content, SoundType.SmallJump, "jump-small", SoundPlayMode.Lazy);
            RegisterSound(content, SoundType.SuperJump, "jump-super", SoundPlayMode.Lazy);
            RegisterSound(content, SoundType.Bump, "bump", SoundPlayMode.Lazy);
            RegisterSound(content, SoundType.BlockBreak, "blockBreak", SoundPlayMode.Lazy);
            RegisterSound(content, SoundType.Stomp, "stomp", SoundPlayMode.Lazy);
            RegisterSound(content, SoundType.Coin, "coin", SoundPlayMode.Lazy);
            RegisterSound(content, SoundType.ItemAppear, "powerUpAppear", SoundPlayMode.Lazy);
            RegisterSound(content, SoundType.PowerUp, "powerUp", SoundPlayMode.Lazy);
            RegisterSound(content, SoundType.Kick, "kick", SoundPlayMode.Lazy);
            RegisterSound(content, SoundType.Pipe, "pipe", SoundPlayMode.Lazy);
            RegisterSound(content, SoundType.NormalFire, "fireball", SoundPlayMode.Eager);
            RegisterSound(content, SoundType.SuperFire, "smb_bowserfire", SoundPlayMode.Eager);
            RegisterSound(content, SoundType.OneUp, "smb_1-up", SoundPlayMode.Lazy);
            RegisterSound(content, SoundType.FlagPole, "smb_flagpole", SoundPlayMode.Lazy);
            RegisterSound(content, SoundType.Firework, "fireworks", SoundPlayMode.Default);
        }

        public static void StopMusic()
        {
            MusicList[ActiveMusic].Stop();
        }

        public static void ResumeLastMusic(bool restart)
        {
            PlayMusic(LastMusic, restart);
        }

        public static void SwitchToOverworldMusic()
        {
            PlayMusic(MusicType.Overworld);
        }

        public static void SwitchToUnderworldMusic()
        {
            PlayMusic(MusicType.Underworld);
        }

        public static void SwitchToFailMusic()
        {
            PlayMusic(MusicType.Fail);
        }

        public static bool FailMusicPlaying
        {
            get { return ActiveMusic == MusicType.Fail && CheckState(MusicType.Fail) == SoundState.Playing; }
        }

        public static bool FailMusicFinished
        {
            get { return ActiveMusic == MusicType.Fail && CheckState(MusicType.Fail) != SoundState.Playing; }
        }

        public static void SwitchToWinMusic()
        {
            PlayMusic(MusicType.Win);
        }

        public static void SwitchToStarPowerMusic()
        {
            PlayMusic(MusicType.StarPower);
        }

        public static void SwitchToHarpMusic()
        {
            PlayMusic(MusicType.Harp);
        }

        public static void SmallJumpSoundPlay()
        {
            PlaySound(SoundType.SmallJump);
        }

        public static void SuperJumpSoundPlay()
        {
            PlaySound(SoundType.SuperJump);
        }

        public static void BumpSoundPlay()
        {
            if (CheckState(SoundType.SmallJump) == SoundState.Playing)
                StopSound(SoundType.SmallJump);
            if (CheckState(SoundType.SuperJump) == SoundState.Playing)
                StopSound(SoundType.SuperJump);
            PlaySound(SoundType.Bump);
        }

        public static void BlockBreakSoundPlay()
        {
            PlaySound(SoundType.BlockBreak);
        }

        public static void StompSoundPlay()
        {
            PlaySound(SoundType.Stomp);
        }

        public static void CoinSoundPlay()
        {
            PlaySound(SoundType.Coin);
        }

        public static void ItemAppearSoundPlay()
        {
            PlaySound(SoundType.ItemAppear);
        }

        public static void PowerUpSoundPlay()
        {
            PlaySound(SoundType.PowerUp);
        }

        public static void PowerDownSoundPlay()
        {
            PipeSoundPlay();
        }

        public static void KickSoundPlay()
        {
            PlaySound(SoundType.Kick);
        }

        public static void PipeSoundPlay()
        {
            PlaySound(SoundType.Pipe);
        }

        public static void FireballSoundPlay()
        {
            PlaySound(SoundType.NormalFire);
        }

        public static void SuperFireSoundPlay()
        {
            PlaySound(SoundType.SuperFire);
        }

        public static void OneUpSoundPlay()
        {
            PlaySound(SoundType.OneUp);
        }

        public static void FlagpoleSoundPlay()
        {
            PlaySound(SoundType.FlagPole);
        }

        public static void FireworkSoundPlay()
        {
            PlaySound(SoundType.Firework);
        }
    }
}