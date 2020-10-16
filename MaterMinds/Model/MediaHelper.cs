using System;
using System.Windows.Media;

namespace MaterMinds.Model
{
    static class MediaHelper 
    {
        public static readonly MediaPlayer backgroundPlayer = new MediaPlayer();
        public static readonly MediaPlayer soundEffectPlayer = new MediaPlayer();
        public static double volume = 1;
        public static bool Muted;

        public static void Mute()
        {
            if(Muted == false)
            {
                Muted = true;
                backgroundPlayer.IsMuted = Muted;
                soundEffectPlayer.IsMuted = Muted;
            }
            else
            {
                Muted = false;
                backgroundPlayer.IsMuted = Muted;
                soundEffectPlayer.IsMuted = Muted;
            }
        }

        public static void PlayMedia(MediaPlayer mediaPlayer, Uri uri)
        {
            if(mediaPlayer == backgroundPlayer)
            {
                backgroundPlayer.Open(uri);
                backgroundPlayer.IsMuted = Muted;
                backgroundPlayer.Play();
            }
            else
            {
                soundEffectPlayer.Open(uri);
                soundEffectPlayer.IsMuted = Muted;
                soundEffectPlayer.Play();
            }
        }
    }
}
