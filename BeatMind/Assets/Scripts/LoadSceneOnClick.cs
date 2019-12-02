using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{

    public void LoadByIndex(int sceneIndex)
    {
        if(this.gameObject.name == "EasyButton")
        {
            DifficultyManager.Instance.difficulty = 4;
        }
        else if(this.gameObject.name == "MediumButton")
        {
            DifficultyManager.Instance.difficulty = 2;
        }
        else if (this.gameObject.name == "HardButton")
        {
            DifficultyManager.Instance.difficulty = 1;
        }



        SceneManager.LoadScene(sceneIndex);
    }
}