using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FakeAnim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float sx = Random.value > 0.5f ? -1 : 1;
        float sy = Random.value > 0.5f ? -1 : 1;

        transform.localScale = new Vector3(sx, sy, 1);
    }
}
