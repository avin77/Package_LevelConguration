using System;
using UnityEditor;
using UnityEngine;
using System.IO;
using System.Collections.Generic;
namespace ezygamers.CMS
{
    public class LevelConfigTool : EditorWindow
    {
        Vector2 scrollpos; // 
        int noofLevel = 1; // no of level
        public List<LevelConfiggSO> levelconfigs = new List<LevelConfiggSO>();

        [MenuItem("Tool/Level Config")]
        public static void ShowWindow()
        {
            GetWindow<LevelConfigTool>("Level Config Window");
        }


        private void OnGUI()
        {
            EditorGUILayout.BeginVertical();
            scrollpos = EditorGUILayout.BeginScrollView(scrollpos);


            //window code
            GUILayout.Label("My tool", EditorStyles.boldLabel);
            noofLevel = EditorGUILayout.IntSlider("noOfLevel", noofLevel, 1, 10); //set the number of level with the help of slider 
            if (GUILayout.Button("LevelConfig"))
            {
                //
                if (levelconfigs.Count < noofLevel)
                {
                    int levelsToAdd = Math.Abs(noofLevel - levelconfigs.Count);
                    for (int i = 0; i < levelsToAdd; i++)
                    {
                        levelconfigs.Add(new LevelConfiggSO { LevelNumber = levelconfigs.Count + 1 });
                    }
                }



            }
            foreach (var levelconfuguration in levelconfigs)
            {
                GUILayout.Label($"Level{levelconfuguration.LevelNumber }");

                levelconfuguration.noOfSubLevel = EditorGUILayout.IntSlider("Number of SubLevel", levelconfuguration.noOfSubLevel, 1, 15);

                if (levelconfuguration.question.Count != levelconfuguration.noOfSubLevel)
                {
                    levelconfuguration.question = new List<QuestionBaseSO>(new QuestionBaseSO[levelconfuguration.noOfSubLevel]);
                }
                for (int j = 0; j < levelconfuguration.noOfSubLevel; j++)
                {
                   
                    levelconfuguration.question[j] = (QuestionBaseSO)EditorGUILayout.ObjectField($"Question {j + 1}", levelconfuguration.question[j], typeof(QuestionBaseSO), false);
                }
               

               

            }
            if (GUILayout.Button("Save level Configuration"))
            {
                
                SaveConfiguration();
            }

            EditorGUILayout.EndScrollView();
            EditorGUILayout.EndVertical();
        }
        private void SaveConfiguration()
        {
            for (int i = 0; i < levelconfigs.Count; i++)
            {
                string path = $"Assets/Levels/LevelData{i + 1}.asset";

                if (File.Exists(path))
                {
                    Debug.Log("File exists");
                    continue;
                }

                AssetDatabase.CreateAsset(levelconfigs[i], path);


            }
            AssetDatabase.SaveAssets();
            Debug.Log("levelsaved");
        }
    }


}
