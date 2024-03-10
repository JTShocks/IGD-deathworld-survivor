using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    int playerLevel=1;
    float playerXp;
    public bool isPaused { get; private set; }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseTime()
    {
        isPaused = true;
        Time.timeScale = 0;
    }
    public void ContinueTime()
    {
        isPaused = false;
        Time.timeScale = 1;
    }
    public void LevelEnded()
    {


    }
     void LevelStarted()
    {


    }
    void LoadNextLevel()
    {

    }
    void PlayerLevelUp()
    {
        playerXp = 0;
        playerLevel++;
        PauseTime();

    }
    void AddXp(float amount)
    {
        playerXp += amount;
        if (playerXp > GameSettings.instance.XpNeeded(playerLevel))
        {
            PlayerLevelUp();
        }
    }

}
