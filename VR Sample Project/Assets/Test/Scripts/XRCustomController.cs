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
            print(context.ReadValue<Vector2>());
        };

        dirrotateRef.action.canceled += delegate (InputAction.CallbackContext context)
        {
            contAnim.RotateActivate(context.ReadValue<Vector2>(), context.performed);
            print(context.ReadValue<Vector2>());
        };


        selectRef.action.performed += contAnim.BumperActivate;
        selectRef.action.canceled += contAnim.BumperActivate;
    }
    private Vector3 moveDir;

    private void OnMove(InputValue inputValue)
    {
        Vector2 inputVector = inputValue.Get<Vector2>();

        moveDir = new Vector3(inputVector.x, 0, inputVector.y);
    }
}
