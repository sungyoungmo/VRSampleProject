using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//using newto



// �Ϲ� 1��¥�� �ּ�

/*
    �Ϲ� ������ �ּ�
*/


/// 1��¥�� ���� �ּ�
/// ���� �ּ��� �������� : �±װ� ���� ���ڴ� �Ϲ� �ּ��� ���� �ƹ� ȿ���� ����
/// <summary>
/// �Ʒ� ���� ��� (class, field, property, method ��)�� ���� �Ϲ� ����
/// </summary>

public class DocCommentTestClass
{
    /// <summary>
    /// �ǹ̾��� <seealso cref="int"/> ����
    /// </summary>
    public int fieldA;

    /// <summary>
    /// �ǹ� ���� Method.
    /// </summary>
    /// <param name="param">�ǹ� ���� �Ķ����.</param>
    public void SomeMethod(string param)
    {

    }


    /// <summary>
    /// �ǹ�
    /// </summary>
    /// <returns>�ǹ� ���� ��ȯ��</returns>
    public int SomeReturnableMethod()
    {
        return 0;
    }
}

/**
 * <summary>
 * ������ ����
 * 1��° ��
 * 2��° ��
 * 3���� ��
 * </summary>
 **/


public class DocCommentTest : MonoBehaviour
{
    [Tooltip("�ʿ��� ��쿡�� ���� �Ҵ��ϼ���. �ƴϸ� 0")]
    public int fieldA;

    [Range(0, 1)]
    public float fieldB;

    public string fieldC;

    private void Start()
    {
        DocCommentTestClass classA = new DocCommentTestClass();
        classA.fieldA = 1;
        fieldA = 1;
        //fieldC = Extentions.IntValueToString(fieldA);
        fieldC = fieldA.IntValueToString();

        // ���� �Ķ���� ��, �Ķ���� ������ ��� ���� Ư�� �Ķ���Ϳ� ���� �����ϰ� ���� ���
        // (�Ķ���� ��: ��) ���·� �Լ� ȣ�� ����.
        fieldC = fieldA.IntValueToString(postfix:"cm");

        string jsonData = new MyData().ToJson();
    }
}

[System.Serializable]
public class MyData
{
    public int level;
    public int stage;
    public int @class;

}

public static class Extentions
{
    //public static string IntValueToString(this int param)
    //{
    //    return param.ToString();
    //}


    /// <summary>
    /// Ȯ�� �޼���: ù ��° �Ķ���͸� . �����ڸ� ���ؼ� ������ �� �ִ� �޼���. 
    /// <br/>
    /// ���� ���� : ������ <see langword="static"/> �޼��忩�� �ϰ�, ����ƽ Ŭ������ ������� ��.
    /// </summary>
    /// <param name="param"></param>
    /// <param name="postfix">default �Ķ���� �Ҵ�: �޼��� ȣ�� �� �Ķ���� ���� �Է����� �ʾƵ� ��. �⺻���� ���޵�</param>
    /// <returns></returns>
    // �����ε��� �Լ��� �ϳ� �� ����� �� ���� �̷��� �⺻���� �����ؼ� ����ϴ� �͵� ����
    // default �Ķ���ʹ� ���ʿ� �����־�� �� �տ� �ִµ� �ڿ��� ���� �޴� �Ķ���� ������ ���� �߻�
    public static string IntValueToString(this int param, string prefix = "",string postfix = "")
    {
        return $"{prefix}{param.ToString()}{postfix}";
    }

    public static string ToJson(this MyData data)
    {
        // TODO: ����
        //retrun JsoUtility.ToJson(data);
        return "a";
    }

}
