using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BarSquare : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    [HideInInspector] public List<BarSquare> followingSquares = new List<BarSquare>();

    public DragableObject contained = null;
    public bool locked = false;
    public bool erased = false;
    public bool hovered = false;

    public Image hoverIndicator;
    public Image erasedImage;



    public void OnPointerEnter(PointerEventData eventData)
    {
        if (MemoryBarManager.instance.dragedObject == null)
            return;

        if (followingSquares.Count < MemoryBarManager.instance.dragedObject.size-1)
            return;

        

        hovered = true;

        if(!locked)
        {
            hoverIndicator.enabled = true;

            for (int i = 0; i < Mathf.Min(followingSquares.Count, MemoryBarManager.instance.dragedObject.size - 1); i++)
            {
                followingSquares[i].hoverIndicator.enabled = true;
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hovered = false;

        if (locked)
            return;

        hoverIndicator.enabled = false;
        if (MemoryBarManager.instance.dragedObject == null)
            return;
        for (int i = 0; i < Mathf.Min(followingSquares.Count, MemoryBarManager.instance.dragedObject.size - 1); i++)
        {
            if (followingSquares[i].locked)
                continue;   
            followingSquares[i].hoverIndicator.enabled = false;
        }
    }




    void Start()
    {
        Unlock();
        MemoryBarManager.instance.OnDrop += OnDrop;
        bool seen = false;
        for (int i = 0; i < MemoryBarManager.instance.barSquares.Count; i++)
        {
            if (seen)
                followingSquares.Add(MemoryBarManager.instance.barSquares[i]);
            if (MemoryBarManager.instance.barSquares[i] == this)
                seen = true;
        }
    }

    void OnDestroy()
    {
        if(MemoryBarManager.instance != null)
            MemoryBarManager.instance.OnDrop -= OnDrop;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void OnDrop()
    {
        if (locked || !hovered)
            return;

        OnAdd(MemoryBarManager.instance.dragedObject);

    }


    private void Lock()
    {
        locked = true;
        hoverIndicator.color = Color.grey;
        hoverIndicator.enabled = true;
    }

    private void Unlock()
    {
        locked = false;
        hoverIndicator.color = Color.yellow;
        hoverIndicator.enabled = false;
    }


    public void OnClick(BaseEventData eventData)
    {
        PointerEventData pointerEventData = (PointerEventData)eventData;
        if (pointerEventData.button == PointerEventData.InputButton.Right)
            OnRemove();
    }

    public void OnAdd(DragableObject objectToAdd)
    {
        OnRemove();

        GameObject draggedObj = Instantiate(objectToAdd.gameObject, transform.position, transform.rotation, transform.parent);
        draggedObj.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100);
        contained = draggedObj.GetComponent<DragableObject>();
        contained.dragged = false;

        contained.transform.SetSiblingIndex(0);

        //Unlock
        for (int i = 0; i < followingSquares.Count; i++)
        {
            if (followingSquares[i].locked)
                followingSquares[i].Unlock();
            else
                break;
        }


        //Lock
        for (int i = 0; i < Mathf.Min(followingSquares.Count, contained.size - 1); i++)
        {
            followingSquares[i].Lock();
            if (followingSquares[i].contained != null)
            {
                Destroy(followingSquares[i].contained.gameObject);
            }
        }

        Image[] imagesDragged = contained.GetComponentsInChildren<Image>();
        for (int i = 0; i < imagesDragged.Length; i++)
        {
            imagesDragged[i].raycastTarget = false;
        }

        OnPointerExit(null);

        CharacterBehaviourManager.instance.AddBehaviour(contained.action);
    }

    public void OnRemove()
    {
        if (contained != null)
        {

            CharacterBehaviourManager.instance.RemoveBehaviour(contained.action);
            Destroy(contained.gameObject);

        }
    }


    public void Erase()
    {
        erased = true;
        erasedImage.enabled = true;
        OnRemove();
    }

}
