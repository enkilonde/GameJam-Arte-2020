using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Regarder : CharacterBehaviour
{

    public Volume volume;
    [Range(0, 1)]
    public float value;

    private float targetVignette = 0;

    public override void CustomUpdate()
    {
        
    }

    public override void OnAdd()
    {
        targetVignette = 0;
    }

    public override void OnRemove()
    {
        targetVignette = value;
    }

    private void Start()
    {
        targetVignette = value;
    }

    private void Update()
    {
        volume.weight = Mathf.Lerp(volume.weight, targetVignette, Time.deltaTime);
        Vignette compo = volume.profile.components[0] as Vignette;
        Vector2 playerScreenPos = Camera.main.WorldToScreenPoint(CharacterBehaviourManager.instance.transform.position);
        playerScreenPos.x /= Screen.width;
        playerScreenPos.y /= Screen.height;
        compo.center.value = playerScreenPos;
    }



}
