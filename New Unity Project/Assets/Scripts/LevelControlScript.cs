using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelControlScript : MonoBehaviour {

    public static LevelControlScript instance = null;
    GameObject levelSign;
    int sceneIndex, levelPassed;

	// Use this for initialization
	void Start () {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        levelSign = GameObject.Find("LevelNumber");

        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelPassed = PlayerPrefs.GetInt("LevelPassed");

	}

    public void youWin()
    {
        if (sceneIndex == 25)
            Invoke("loadMainMenu", 1f);
        else
        {
            if (levelPassed < sceneIndex)
                PlayerPrefs.SetInt("LevelPassed", sceneIndex);
            Invoke("loadNextLevel", 1f);
        }
    }

    public void youLose()
    {
        Invoke("loadMainMenu", 1f);
    }

    public void loadNextLevel()
    {
        SceneManager.LoadScene(sceneIndex + 1);
    }
	
    void loadMainMenu()
    {
        SceneManager.LoadScene("CountingLevelSelect");
    }

}
