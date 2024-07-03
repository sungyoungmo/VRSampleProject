using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public delegate void SomeEvent(int a);

public class CSharpEventTest : MonoBehaviour
{
    // C#의 이벤트란
    // 1. 이벤트를 선언한 클래스만 호출할 수 있다.
    // 2. delegate 필드는 Interface에서 선언할 수 없지만 event는 가능
    // 이런 불편한 Event가 존재하는 이유는 Observer 패턴의 구현을 위해서이다.

    public event SomeEvent someEvent;
    public event Action<int, int> someAction;
    public event Func<int, int> someFunc;

    private void Start()
    {
        EventTestClass testClass = new EventTestClass();
        testClass.OnInit(this);

        someEvent?.Invoke(1);
    }

}

public class EventTestClass
{
    public void OnInit(CSharpEventTest tester)
    {
        tester.someEvent += (int a) => { new GameObject(a.ToString()); };

        
    }
}

public interface IDestroyable
{
    public event SomeEvent OnDestroy;
}

public class DestroyWhen10Sec : IDestroyable
{
    public event SomeEvent OnDestroy;

    // 10초후에 파괴되면서 호출될 함수
    private void WhenDestroy()
    {
        //파괴되는 절차를 수행 후에
        OnDestroy?.Invoke(1);
    }
}