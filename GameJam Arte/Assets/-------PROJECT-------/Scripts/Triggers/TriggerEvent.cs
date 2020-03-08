﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TriggerEvent : MonoBehaviour
{
    public abstract void OnCustomTriggerEnter();

    public abstract void OnCustomTriggerExit();
}
