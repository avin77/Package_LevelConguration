using UnityEngine;

namespace ezygamers.CMS
{
    [System.Serializable]
    public class AudioContent
    {
        public AudioClip audioClip;

        public AudioContent(AudioClip audioClip)
        {
            this.audioClip = audioClip;
        }
    }


}
