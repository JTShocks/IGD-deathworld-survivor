using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelThemeLibrary", menuName = "LevelThemeLibrary", order = 1)]
public class LevelThemeLibrary : ScriptableObject
{
    [SerializeField]
    List<LevelTheme> levelThemes;

    public LevelTheme GetRandomLevel()
    {
        return levelThemes[Random.Range(0, levelThemes.Count)];
    }
   
}
