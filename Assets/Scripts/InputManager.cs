using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Camera mainCamera;
    private ITarget currentTarget;

    private void Start()
    {
        mainCamera = Camera.main; // Get the main camera
        currentTarget = new NullTarget(); // Set the current target to NullTarget initially
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                ITarget target = hit.collider.GetComponent<ITarget>();

                if(target != null)
                {
                    currentTarget = target;
                }
                else
                {
                    currentTarget = new NullTarget();
                }
            }
        }
        else
        {
            currentTarget = new NullTarget();
        }

        currentTarget.OnClick();
    }
}