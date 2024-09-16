using UnityEngine;

public class NullTarget : ITarget
{
    public void OnClick()
    {
        Debug.Log("No target was clicked");
    }
}