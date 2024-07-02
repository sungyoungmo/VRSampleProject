using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRTest : MonoBehaviour
{
    public void Print(string message) => print(message);

    

    public void FirstSelectEnterEvent(SelectEnterEventArgs args)
    {
        

        if (args.interactableObject.transform.parent != null)
        {
            print($"{args.interactableObject.transform.name}" + $"�� {args.interactableObject.transform.parent.name}���� ���� ���õ�");
        }
        else
        {
            print($"{args.interactableObject.transform.name}");
        }

        
        

    }
    public void LastSelectExitEvent(SelectExitEventArgs args)
    {
        if (args.interactableObject.transform.parent != null)
        {
            print($"{args.interactableObject.transform.name}" + $"�� {args.interactableObject.transform.parent.name}���� ���������� ����������");
        }
        else
        {
            
        }

            
    }

    public void SelectEnterEvent(SelectEnterEventArgs args)
    {
        if (args.interactableObject.transform.parent != null)
        {
            print($"{args.interactableObject.transform.name}" + $"�� {args.interactableObject.transform.parent.name}���� ���õ�");
        }
        else
        {
            print($"{args.interactableObject.transform.name}");
        }
            
    }

    public void SelectExitEvent(SelectExitEventArgs args)
    {
        if (args.interactableObject.transform.parent != null)
        {
            print($"{args.interactableObject.transform.name}" + $"�� {args.interactableObject.transform.parent.name}���� ����������");
        }
        else
        {
            print($"{args.interactableObject.transform.name}");
        }
            
    }

    float times = 0;
    private void Update()
    {
        times += Time.deltaTime;
    }

    public void ActivateEvent(BaseInteractionEventArgs args)
    {

        if (args.GetType() == typeof(ActivateEventArgs))
        {
            print("��");
            StartCoroutine(modifiedColor(args));   
        }
        else if (args.GetType() == typeof(DeactivateEventArgs))
        {
            print("��Ĭ");
        }
        else
        {
            print("");
        }
    }

    IEnumerator modifiedColor(BaseInteractionEventArgs args)
    {
        times = 0;
        while (true)
        {
            times += 2.0f * Time.deltaTime;

            args.interactableObject.transform.GetComponent<Renderer>().material.color = new Color(Mathf.Lerp(0, 1, times), 1, 1, 1);
            print(times);

            yield return new WaitForSeconds(0.1f);

            if (times <= 1)
                break;
        }


        yield return null;
    }
}
