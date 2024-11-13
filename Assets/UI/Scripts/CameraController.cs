using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] public float speed = 5.0f; 
    [SerializeField] public float mouseSensitivity = 2.0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get input for movement on the X and Z axes
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        float upDown;
        upDown = Input.GetKey(KeyCode.LeftControl) ? -1 : 0;
        upDown += Input.GetKey(KeyCode.Space) ? 1 : 0;
        Vector3 direction = new Vector3(horizontal, upDown, vertical).normalized;

        // Rotate the player based on mouse movement
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        float eulerAnglesX = -mouseY + transform.rotation.eulerAngles.x;
        float eulerAnglesY = mouseX + transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Euler(eulerAnglesX, eulerAnglesY, 0);

        // Check if there's input to move the character
        if (direction.magnitude >= 0.1f)
        {
            // Move the character forward relative to its current rotation
            Vector3 moveDirection = transform.TransformDirection(direction) * speed * Time.deltaTime;
            characterController.Move(moveDirection);
        }
    }
}
