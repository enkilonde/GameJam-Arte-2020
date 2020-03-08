using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public string levelName = "";
    public float delay = 0;

    public void LoadScene()
    {
        StartCoroutine(loadLvl(levelName));
    }

    public void LoadScene(string levelname)
    {
        StartCoroutine(loadLvl(levelname));
    }

    public IEnumerator loadLvl(string lvlName)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(lvlName);

    }

}
