using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ezygamer.CMS
{
    public class LevelConfigSO : ScriptableObject
    {
        public int LevelNumber;
        public Sprite backgroudSprite;
        public int noOfwords = 1;

        public List<string> words = new List<string>();

        public string correctans;





    }
}

