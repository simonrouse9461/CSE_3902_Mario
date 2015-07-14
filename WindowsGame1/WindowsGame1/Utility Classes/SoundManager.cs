﻿using System.Collections.ObjectModel;
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

        public static void LoadAllSounds(ContentManager content)
        {
            overworldMusic = content.Load<SoundEffect>("Audio/overworldMusic");
            jumpSound = content.Load<SoundEffect>("Audio/jump");
            blockBreakSound = content.Load<SoundEffect>("Audio/blockBreak");
            stompSound = content.Load<SoundEffect>("Audio/stomp");
        }

        public static void overworldMusicPlay()
        {
            currentlyPlayingMusic = overworldMusic.CreateInstance();
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
    }
}