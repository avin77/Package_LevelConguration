using System;
using System.Collections;
using UnityEngine;

namespace ezygamers.CMS
{
    [System.Serializable]
    public abstract class  OptionData
    {
        public abstract Sprite GetSprite();
        public abstract string GetText();

        public abstract AudioClip GetAudioClip();
        
    }

}
