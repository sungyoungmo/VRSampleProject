using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UITurotialLobby : MonoBehaviour
{
    public Dropdown dropdown;
    public Button button;
    private int selectedSceneIndex;

    public List<string> sceneNames = new List<string>();

    private void Awake()
    {
        // ��Ӵٿ� �ɼ� ����Ʈ ����
        List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();

        // sceneNames ���� ��ü ���� �ݺ�
        foreach (string sceneName in sceneNames)
        {
            options.Add(new Dropdown.OptionData(sceneName));
        }

        // ��Ӵٿ� �ɼ� ����Ʈ ��ü
        dropdown.options = options; 

        // ��Ӵٿ� OnvalueChanged �̺�Ʈ�� SceneSelectionChanged �߰�
        dropdown.onValueChanged.AddListener(SceneSelectionChange);

        button.onClick.AddListener(MoveButtonClick);


    }

    public void SceneSelectionChange(int index)
    {
        selectedSceneIndex = index;
    }

    public void MoveButtonClick()
    {
        SceneManager.LoadScene(selectedSceneIndex);
    }
}
