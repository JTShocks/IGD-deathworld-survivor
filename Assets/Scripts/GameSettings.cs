using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CreateAssetMenu(fileName ="GameSettings",menuName ="GameSettings",order =1)]
public class GameSettings : ScriptableSingleton<GameSettings>
{
    [SerializeField]
    int baseXpNeeded;

    public int XpNeeded(int currentLevel)
    {
        return baseXpNeeded*currentLevel;
    }

}
