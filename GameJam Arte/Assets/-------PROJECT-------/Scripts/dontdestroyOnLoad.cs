﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontdestroyOnLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

}
