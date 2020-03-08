using UnityEngine;
using UnityEngine.Events;

public abstract class BaseTrigger : MonoBehaviour
{
    [Header("Trigger Events")]
    public TriggerEvent[] events;

    [Header("Events")]
    public UnityEvent onTriggerEnter;
    public UnityEvent onTriggerExit;

    public void TriggerEnterEvent()
    {
        for (int i = 0; i < events.Length; i++)
        {
            events[i].OnCustomTriggerEnter();
        }

        onTriggerEnter.Invoke();
        OnTriggerEnterCustom();
    }

    public void TriggerExitEvent()
    {
        for (int i = 0; i < events.Length; i++)
        {
            events[i].OnCustomTriggerExit();
        }

        onTriggerExit.Invoke();
        OnTriggerExitCustom();
    }

    protected virtual void OnTriggerEnterCustom() { }

    protected virtual void OnTriggerExitCustom() { }
}


