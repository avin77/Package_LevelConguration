﻿using UnityEngine;

namespace ezygamers.CMS
{
    [System.Serializable]
    public class TextOption : OptionData
    {
        public string text;

        public override AudioClip GetAudioClip()
        {
            return null;
        }

        public override Sprite GetSprite()
        {
            return null;
        }

        public override string GetText()
        {
            return text;
        }
    }


}
