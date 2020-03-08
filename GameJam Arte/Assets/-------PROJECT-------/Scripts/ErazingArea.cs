using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ErazingArea : MonoBehaviour
{

    public UnityEvent OnErase;
    public Animator animator;

    public UnityEvent OnStop;

    private bool active = true;
    public void Stop()
    {
        animator.SetTrigger("stop");
        active = false;
        OnStop?.Invoke();
    }

    public void Restart()
    {
        animator.SetTrigger("restart");
        active = true;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
            return;
        if (!active)
            return;
        MemoryBarManager.instance.EraseRight();
        OnErase?.Invoke();
    }


}
