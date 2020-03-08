using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public string levelName = "";


    public void LoadScene()
    {
        SceneManager.LoadScene(levelName);
    }

    public void LoadScene(string levelname)
    {
        SceneManager.LoadScene(levelname);
    }

}
