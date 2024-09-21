﻿using UnityEngine;

namespace ezygamers.CMS
{
    [System.Serializable]
    public class AudioOption : OptionData
    {
        public AudioClip audio;
        public override AudioClip GetAudioClip()
        {
            return audio;
        }

        public override Sprite GetSprite()
        {
            return null;
        }

        public override string GetText()
        {
            return null;
        }
    }


}
