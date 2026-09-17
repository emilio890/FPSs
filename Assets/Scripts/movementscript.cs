using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class movementscript : MonoBehaviour
{
    [SerializeField]
    private InputAction movementInput;
    [SerializeField]
    private InputAction jumpInput;
    [SerializeField]
    private float jumps;
    [SerializeField]
    private InputAction runinput;
    [SerializeField]
    private float run;
    CharacterController controller;

    private float playerSpeed = 5.0f;
    private float gravityValue = -9.81f;

    private Vector3 playervelocity;
    private bool grounded;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    private void OnEnable()
    {
        movementInput.Enable();
        jumpInput.Enable();
        runinput.Enable();
    }
    private void OnDisable()
    {
        movementInput.Disable();
        jumpInput.Disable();
        runinput.Disable();
    }

    void Start()
    {
        
    }


    void Update()
    {
        if (gamemanager.instance.isplaying == true)
        {
            grounded = controller.isGrounded;
            if (grounded)
            {
                if (playervelocity.y < -2)
                {
                    playervelocity.y = -1;
                }
            }
            Vector2 Movement = movementInput.ReadValue<Vector2>();
            Vector3 Direction = transform.right * Movement.x + transform.forward * Movement.y;
            Direction = Vector3.ClampMagnitude(Direction, 1);

            if (grounded && jumpInput.triggered)
            {
                playervelocity.y = Mathf.Sqrt(jumps * -2 * gravityValue);
            }

            playervelocity.y += gravityValue * Time.deltaTime;

            Vector3 finalMove = Direction * playerSpeed + Vector3.up * playervelocity.y;

            controller.Move(finalMove * Time.deltaTime);
        }
    }
    
}
