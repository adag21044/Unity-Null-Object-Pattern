# Unity Null Object Pattern

This Unity project demonstrates the **Null Object Pattern** with **SOLID principles**. The project allows users to click on objects in the scene, and if no object is clicked, the program handles it gracefully using the `NullTarget` class to avoid errors.

## Project Overview

In this project, the user can click anywhere in the scene. If a clickable object (with a `RealTarget` component) is clicked, a specific action will be triggered for that object. If no object is clicked, the `NullTarget` class will handle the click without throwing an error, adhering to the **Null Object Pattern**.

### Design Patterns Used

- **Null Object Pattern**: Prevents `null` checks by providing a "do-nothing" object (`NullTarget`) when no real target is clicked.
- **SOLID Principles**:
  - **Single Responsibility Principle**: Each class (`InputManager`, `RealTarget`, `NullTarget`) has a single responsibility.
  - **Open/Closed Principle**: New types of targets (real or null) can be added without modifying the existing code.
  - **Liskov Substitution Principle**: `RealTarget` and `NullTarget` can be used interchangeably where `ITarget` is expected.
  - **Interface Segregation Principle**: The `ITarget` interface defines only the necessary method for the target (`OnClick`).
  - **Dependency Inversion Principle**: `InputManager` depends on the abstraction `ITarget`, not concrete implementations (`RealTarget`, `NullTarget`).

## Code Structure

### InputManager.cs

Handles the input from the user and determines whether a target was clicked. If no target is clicked, it defaults to `NullTarget`.

```csharp
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
```

### ITarget.cs

Defines the interface for clickable targets.

```csharp
public interface ITarget
{
    void OnClick();
}
```

### NullTarget.cs

Implements the `ITarget` interface but does nothing when clicked.

```csharp
using UnityEngine;

public class NullTarget : ITarget
{
    public void OnClick()
    {
        Debug.Log("No target was clicked");
    }
}
```

### RealTarget.cs

Implements the `ITarget` interface and performs an action when clicked (logs the object name).

```csharp
using UnityEngine;

public class RealTarget : MonoBehaviour, ITarget
{
    public void OnClick()
    {
        Debug.Log($"{gameObject.name} was clicked");
    }
}
```
