
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontdestroyOnLoad : MonoBehaviour
{
    public static List<string> gameObjects = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        if (gameObjects.Contains(gameObject.name))
            return;
        DontDestroyOnLoad(gameObject);
        gameObjects.Add(gameObject.name);
    }

}
