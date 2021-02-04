using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class vghjqsdighvuisuiohj : MonoBehaviour
{
    public VisualEffect vfx;
    public string eventName;

    private void Update()
    {
        if (Input.GetKeyDown("f3"))
        {
            vfx.SendEvent(eventName);
        }
    }
}
