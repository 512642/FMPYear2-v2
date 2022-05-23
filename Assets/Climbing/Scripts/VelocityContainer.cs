using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Instead of creating a custom controller, we add a simple component to hold the action.
/// </summary>
public class VelocityContainer : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public ClimbingProvider climbing;
    Vector3 mountVelocity;
    [SerializeField] private InputActionProperty velocityInput;

    private void Start()
    {
        mountVelocity = playerMovement.velocity;
    }
    public Vector3 Velocity => velocityInput.action.ReadValue<Vector3>();


    public void LaunchOnRelease(VelocityContainer provider)
    {
        if(!climbing.activeVelocities.Contains(provider))
            mountVelocity.y = 3;
    }
        

}
