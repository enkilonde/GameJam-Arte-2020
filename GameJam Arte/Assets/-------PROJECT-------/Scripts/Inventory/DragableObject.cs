using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragableObject : MonoBehaviour, IBeginDragHandler
{
    public bool dragged = false;
    RectTransform rectTransform;

    public float size = 1;
    public Actions action;
    //public CharacterBehaviour characterBehaviour;

    CanvasScaler scaler;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Input.GetMouseButton(2))
            return;
        GameObject draggedObj = Instantiate(gameObject, transform.position, transform.rotation, transform.parent);
        DragableObject dra = draggedObj.GetComponent<DragableObject>();
        dra.dragged = true;

        Image[] imagesDragged = dra.GetComponentsInChildren<Image>();
        for (int i = 0; i < imagesDragged.Length; i++)
        {
            imagesDragged[i].raycastTarget = false;
        }

        MemoryBarManager.instance.dragedObject = dra;
    }

    public void OnClick(BaseEventData eventData)
    {
        PointerEventData pointerEventData = (PointerEventData)eventData;
        if (pointerEventData.button == PointerEventData.InputButton.Middle)
            MemoryBarManager.instance.AddBehaviour(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        scaler = GetComponentInParent<CanvasScaler>();
    }

    // Update is called once per frame
    void Update()
    {
        if(dragged)
        {

            float refWidth = scaler.referenceResolution.x;
            float refHeight = scaler.referenceResolution.y;
            float ratioX = refWidth / Screen.width;
            float ratioY = refHeight / Screen.height;
            Debug.Log(ratioX + " , " + ratioY);

            Vector2 pos = new Vector2(Input.mousePosition.x * ratioX, Input.mousePosition.y * ratioY);

            rectTransform.anchoredPosition = pos;

            if (Input.GetMouseButtonUp(0))
            {
                MemoryBarManager.instance.OnDrop();
                Destroy(gameObject);
            }
        }

        //Cheat code to add all
        if(Input.GetKeyUp(KeyCode.C))
        {
            MemoryBarManager.instance.AddBehaviour(this);
        }

    }
}
