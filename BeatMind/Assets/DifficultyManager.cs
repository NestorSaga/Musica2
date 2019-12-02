using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    // Start is called before the first frame update

    public int difficulty;

    public static DifficultyManager Instance
    {
        get
        {
            return instance;
        }
    }
    private static DifficultyManager instance = null;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    
    public void SetDifficulty(string l_difficulty)
    {
        switch (l_difficulty)
        {
            case "easy":
                difficulty = 4;
                break;
            case "medium":
                difficulty = 2;
                break;
            case "hard":
                difficulty = 1;
                break;
        }
    }


}
