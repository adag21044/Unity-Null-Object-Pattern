using UnityEngine;

public class RealTarget : MonoBehaviour, ITarget
{
    public void OnClick()
    {
        Debug.Log($"{gameObject.name} was clicked");
    }
}