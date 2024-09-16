using UnityEngine;

public class NullTarget : MonoBehaviour, ITarget
{
    public void OnClick()
    {
        Debug.Log("No target was clicked");
    }
}