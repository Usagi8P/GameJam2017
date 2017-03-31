using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public void LoadLevel(string name)
    {
        Debug.Log("Level load requested for: " + name);
        UnityEngine.SceneManagement.SceneManager.LoadScene(name);
    }

    public void QuitGame()
    {
        Debug.Log("Game quitted");
        Application.Quit();
    }
}
