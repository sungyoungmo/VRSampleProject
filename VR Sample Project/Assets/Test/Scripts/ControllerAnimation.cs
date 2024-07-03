using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerAnimation : MonoBehaviour
{
    public Transform trigger;
    public Transform bumper;
    public Transform thumbStick;

    public void TriggerActivate(bool isPush)
    {
        trigger.transform.Rotate(isPush ? -10 : 10, 0, 0);
    }

    public void BumperActivate(InputAction.CallbackContext context)
    {
        bumper.transform.Translate(context.performed ? 0.002f : -0.002f, 0, 0);
    }

    public void RotateActivate(Vector2 rotValue, bool isPush)
    {
        if (isPush)
        {
            thumbStick.transform.Rotate(rotValue.y * -30, 0, rotValue.x * 30);
        }
        else
        {
            //thumbStick.transform.Rotate(rotValue.x * 10, 0,rotValue.y * 10);
            thumbStick.transform.localEulerAngles = new Vector3(0,0,0);
        }

        
    }
}
