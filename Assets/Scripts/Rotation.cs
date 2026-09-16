using UnityEngine;
using UnityEngine.InputSystem;

public class Rotation : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    private float xRotation = 0;

    [SerializeField]
    private float xSensitivity = 100;
    [SerializeField]
    private float ySensivity;
    void Start()
    {
        
    }

 
    void Update()
    {
        if (Mouse.current == null) return;
        Vector2 mouseInput = Mouse.current.delta.ReadValue();
        xRotation -= mouseInput.y * ySensivity;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.Rotate(0f, mouseInput.x * ySensivity, 0);
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        
    }
}
