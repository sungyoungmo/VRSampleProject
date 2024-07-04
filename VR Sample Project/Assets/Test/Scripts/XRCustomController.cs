using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;



// ��Ʈ�ѷ� �Է¿� �߰� �׼��� �ϵ��� ����� ������Ʈ
//[RequireComponent(typeof(ActionBasedController))]
public class XRCustomController : MonoBehaviour
{

    public ActionBasedController targetCont;
    private InputActionReference activateRef;   // ���� Ʈ���� ��ư
    private InputActionReference selectRef;     // ���� ���� ��ư
    public InputActionReference buttonA;
    private InputActionReference dirrotateRef;

    private ControllerAnimation contAnim;

    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        contAnim = GetComponentInChildren<ControllerAnimation>();

        activateRef = targetCont.activateAction.reference;
        selectRef = targetCont.selectAction.reference;
        dirrotateRef = targetCont.directionalAnchorRotationAction.reference;
        

        activateRef.action.performed += delegate (InputAction.CallbackContext context)
        {
            contAnim.TriggerActivate(context.performed);
            
        };

        activateRef.action.canceled += delegate (InputAction.CallbackContext context)
        {
            contAnim.TriggerActivate(context.performed);
        };


        dirrotateRef.action.performed += delegate (InputAction.CallbackContext context)
        {
            contAnim.RotateActivate(context.ReadValue<Vector2>(),context.performed);
        };

        dirrotateRef.action.canceled += delegate (InputAction.CallbackContext context)
        {
            contAnim.RotateActivate(context.ReadValue<Vector2>(), context.performed);
        };

        selectRef.action.performed += contAnim.BumperActivate;
        selectRef.action.canceled += contAnim.BumperActivate;
    }
}
