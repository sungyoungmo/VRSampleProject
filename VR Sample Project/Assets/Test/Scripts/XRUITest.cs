using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class XRUITest : MonoBehaviour
{
    Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
        // Awake에 AddListener 많이 씀

    }

    private void OnClick()
    {
        Debug.Log("클릭");
    }

}
