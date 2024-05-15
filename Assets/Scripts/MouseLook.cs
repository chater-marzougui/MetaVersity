using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class mouselook : MonoBehaviour
{
    public InputActionReference HorizontalLook;
    public InputActionReference VerticalLook;
    public float LookSpeed = 1f;
    public Transform cameraTransform;
    float pitch;
    float yaw;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        HorizontalLook.action.performed += HandleHorizontalLookChange;
        VerticalLook.action.performed += HandleVerticalLookChange;
    }

void HandleHorizontalLookChange (InputAction.CallbackContext obj)
{
    yaw += obj.ReadValue<float>();
    transform.localRotation = Quaternion.AngleAxis(yaw * LookSpeed, Vector3.up);
}

void HandleVerticalLookChange (InputAction.CallbackContext obj)
{
    pitch-= obj.ReadValue< float>();
    cameraTransform.localRotation = Quaternion.AngleAxis(pitch * LookSpeed*0, Vector3.right);
}
}