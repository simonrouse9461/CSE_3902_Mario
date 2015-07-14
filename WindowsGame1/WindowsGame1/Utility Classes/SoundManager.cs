using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public static class SoundManager
    {
        private static SoundEffectInstance music;
        private static SoundEffect boing;

        public static void LoadAllSounds(ContentManager content)
        {
            music = content.Load<SoundEffect>("music").CreateInstance();
            music.IsLooped = true;

            boing = content.Load<SoundEffect>("boing");
        }

        public static void playOverworldMusic()
        {
            music.Play();
        }

        public static void playBoing()
        {
            boing.Play();
        }
    }
}