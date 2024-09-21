using UnityEngine;

namespace ezygamers.CMS
{
    [System.Serializable]
    public class ImageOption : OptionData
    {
        public Sprite sprite;

        public override AudioClip GetAudioClip()
        {
            return null;
        }

        public override Sprite GetSprite()
        {
            return sprite;
        }

        public override string GetText()
        {
            return null;
        }
    }


}
