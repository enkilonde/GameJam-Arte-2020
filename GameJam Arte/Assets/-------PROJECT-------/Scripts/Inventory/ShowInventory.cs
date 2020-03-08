using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShowInventory : MonoBehaviour
{
    public UnityEvent OnOpen;
    public UnityEvent OnClose;

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
    
    public void Open()
    {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;
    }

    public void Close()
    {
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;
    }

}
