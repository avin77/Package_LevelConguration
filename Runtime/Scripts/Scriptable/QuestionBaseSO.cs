using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ezygamers.CMS
{
 [CreateAssetMenu(fileName ="Question Base",menuName ="Create QuestionBase")]
    public class QuestionBaseSO:ScriptableObject
    {
        public int questionNo;
        
        [Header("Question Content")]
        public TextContent questionText;
        public TextContent hindiText;
        public ImageContent questionImage;
        public AudioContent questionAudio;

        [Header("English Option Data")]
        public List<TextOption> englishWordsOptions = new List<TextOption>();

        [Header("Hindi Option Data")]
        public List<TextOption> hindiWordsOption = new List<TextOption>();
        [Header("Image Option Data")]
        public List<ImageOption> imageOptions = new List<ImageOption>();
        [Header("Audio Option Data")]
        public List<AudioOption>audioOptions=new List<AudioOption>();
       
        [Header("Correct Answer")]
        public int correctAnswerIndex;

        [Header("Content Type")]
        public ContentType contentType;
        public DifficultyLevel difficultyLevel;


    }

    public enum ContentType
    {
        Learning,
        Question

    }
    public enum DifficultyLevel {
        Easy,
        Medium,
        Hard
    
    }

}
