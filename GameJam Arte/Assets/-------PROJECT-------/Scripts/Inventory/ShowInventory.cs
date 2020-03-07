﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInventory : MonoBehaviour
{

    private Canvas canvas;
    public CanvasGroup canvasGroup;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.I))
        {
            canvasGroup.alpha = 1 - canvasGroup.alpha;
            canvasGroup.blocksRaycasts = !canvasGroup.blocksRaycasts;
            canvasGroup.interactable = !canvasGroup.interactable;
        }
    }
}
