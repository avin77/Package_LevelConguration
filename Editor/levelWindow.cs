using System;
using UnityEditor;
using UnityEngine;
using System.IO;
using System.Collections.Generic;
namespace ezygamer.CMS
{
    public class LevelWindow : EditorWindow
    {
        Vector2 scrollpos; // 
        int noofLevel = 1; // no of level
        public List<LevelConfig> levelconfigs = new List<LevelConfig>();

        [MenuItem("Tool/levelWindow")]
        public static void ShowWindow()
        {
            GetWindow<LevelWindow>("Level Window");
        }

        private void OnEnable()
        {
            string FolderPath = $"Assets/Levels";
            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }
            else
            {
                LoadConfiguration();
            }


        }


        private void OnGUI()
        {
            EditorGUILayout.BeginVertical();
            scrollpos = EditorGUILayout.BeginScrollView(scrollpos);
            //window code
            GUILayout.Label("My tool", EditorStyles.boldLabel);
            noofLevel = EditorGUILayout.IntSlider("noOfLevel", noofLevel, 1, 10); //set the number of level with the help of slider 
                                                                                  //use to configure the level based on number of level
            if (GUILayout.Button("LevelConfig"))
            {
                //
                if (levelconfigs.Count < noofLevel)
                {
                    int levelsToAdd = Math.Abs(noofLevel - levelconfigs.Count);
                    for (int i = 0; i < levelsToAdd; i++)
                    {
                        levelconfigs.Add(new LevelConfig { LevelNumber = levelconfigs.Count + 1 });
                    }
                }
            }

            //after pressing level config button it iterate through each level configuration


            foreach (var levelconfuguration in levelconfigs)
            {
                //name of the level
                GUILayout.Label($"Level{levelconfuguration.LevelNumber }");
                //here you can assign the background sprite
                levelconfuguration.backgroudSprite = (Sprite)EditorGUILayout.ObjectField("Background Image", levelconfuguration.backgroudSprite, typeof(Sprite), false);
                //here you can assign the correct answer
                levelconfuguration.correctans = EditorGUILayout.TextField("Correct Ans", levelconfuguration.correctans);
                // set the  number of words 
                levelconfuguration.noOfwords = EditorGUILayout.IntSlider("Number of Words", levelconfuguration.noOfwords, 1, 5);
                //

                // add string in list of words based on number of words
                if (levelconfuguration.words.Count < levelconfuguration.noOfwords)
                {
                    levelconfuguration.words.AddRange(new string[levelconfuguration.noOfwords - levelconfuguration.words.Count]);
                }
                //remove string from the list of words based on number of words
                else if (levelconfuguration.words.Count > levelconfuguration.noOfwords)
                {
                    levelconfuguration.words.RemoveRange(levelconfuguration.noOfwords, levelconfuguration.words.Count - levelconfuguration.noOfwords);
                }


                for (int j = 0; j < levelconfuguration.noOfwords; j++)
                {

                    if (j == 0)
                    {
                        //add the correct ans on element zero in the list of words
                        levelconfuguration.words[j] = EditorGUILayout.TextField($"Words{j + 1 }", levelconfuguration.correctans);

                    }
                    else
                    {

                        levelconfuguration.words[j] = EditorGUILayout.TextField($"Words{j + 1 }", levelconfuguration.words[j]);
                    }

                }
            }





            //
            if (GUILayout.Button("Save level Configuration"))
            {
                //save the level configuration in the asset database
                SaveConfiguration();
            }
            //clear the asset database 
            if (GUILayout.Button("Clear Database"))
            {
                ClearlevelConfiguration();
            }

            EditorGUILayout.EndScrollView();
            EditorGUILayout.EndVertical();
        }

        // load the level configuration
        private void LoadConfiguration()
        {
            levelconfigs.Clear(); //clear the list

            string folderPath = "Assets/Levels/";
            // If there is no such Directory 
            if (!Directory.Exists(folderPath))
            {
                Debug.LogWarning("The directory does not exist: " + folderPath);
                return;
            }

            //The *.asset pattern tells Directory.GetFiles to find all files with the .asset extension in the specified folder
            string[] assetPaths = Directory.GetFiles(folderPath, "*.asset");

            foreach (string assetPath in assetPaths)
            {
                LevelConfig levelConfig = AssetDatabase.LoadAssetAtPath<LevelConfig>(assetPath);
                if (levelConfig != null)
                {
                    //add to the list of levelCongis
                    levelconfigs.Add(levelConfig);
                }
            }

            noofLevel = levelconfigs.Count;
            Debug.Log("Loaded level configurations.");

        }


        // save the asset in dedicated path
        private void SaveConfiguration()
        {
            for (int i = 0; i < levelconfigs.Count; i++)
            {
                string path = $"Assets/Levels/LevelConfig_{i + 1}.asset";

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
        //clear the level configuration from the dedicated path
        private void ClearlevelConfiguration()
        {
            for (int i = 0; i < levelconfigs.Count; i++)
            {
                string path = $"Assets/Levels/LevelConfig_{i + 1}.asset";
                AssetDatabase.DeleteAsset(path);

            }
            levelconfigs.Clear();// clear the list 
            Debug.Log("clear");

        }



    }
}