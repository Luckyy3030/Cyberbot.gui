using System.Media;

namespace CyberSecurityAwarenessBot.Classes
{
    public class SoundManager
    {
        public static void PlayWelcomeSound()
        {
            try
            {
                SoundPlayer player =
                    new SoundPlayer("welcome.wav");

                player.Play();
            }
            catch
            {

            }
        }

        public static void PlaySendSound()
        {
            try
            {
                SoundPlayer player =
                    new SoundPlayer("send.wav");

                player.Play();
            }
            catch
            {

            }
        }

    }
}