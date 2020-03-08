using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErazingArea : MonoBehaviour
{


    public void Stop()
    {
        GetComponentInChildren<Animator>().SetTrigger("stop");
    }

    public void Restart()
    {
        GetComponentInChildren<Animator>().SetTrigger("restart");

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
            return;
        MemoryBarManager.instance.EraseRight();
    }


}
