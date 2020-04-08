using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class AbilityHandler : MonoBehaviour
{
    public UnityEvent itemInstance;

    public void Add()
    {
        itemInstance.Invoke();
    }

    public void Remove()
    {
        itemInstance.Invoke();
    }
}
