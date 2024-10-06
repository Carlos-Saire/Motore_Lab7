using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    [Header("Player")]
    private Rigidbody Rb;
    private AudioSource audioSource;
    private float Xdirection;
    private float Zdirection;
    private float newRun;
    [SerializeField] private float Speed;
    [SerializeField] private float run;
    [Header("Camera")]
    [SerializeField] private Transform cameraTransform;
    private Vector3 forward;
    private Vector3 right;
    private Vector3 moveDirection;
    [Header("Raycast")]
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float jumpForce;
    private bool isjump;
    [Header("SFX")]
    [SerializeField] AudioClipSO audioClipSo;
    private void Awake()
    {
        Rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        newRun = run;
        run = 1;
    }
    private void FixedUpdate()
    {
        Rb.velocity = new Vector3(moveDirection.x * Speed * run, Rb.velocity.y, moveDirection.z * Speed);
        if (Physics.Raycast(transform.position, Vector3.down, 1.03f, groundLayer))
        {
            if (isjump)
            {
                Rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
                audioClipSo.PlayOneShoot();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Terminar"))
        {
            SceneManager.LoadScene("Game1");
        }
    }
    private void Update()
    {
        forward = cameraTransform.forward;
        right = cameraTransform.right;
        moveDirection = (forward * Zdirection + right * Xdirection).normalized;
    }
    public void XDirection(InputAction.CallbackContext context)
    {
        Xdirection=context.ReadValue<float>();
        CheckMovementSound();
    }
    public void ZDirection(InputAction.CallbackContext context)
    {
        Zdirection = context.ReadValue<float>();
        CheckMovementSound();
    }
    public void Jump(InputAction.CallbackContext context)
    {
        isjump = context.performed;
    }
    public void Run(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            run = newRun;
            audioSource.pitch = 2f;
        }
        else if (context.canceled)
        {
            run = 1;
            audioSource.pitch = 1.0f;
        }
    }
    private void CheckMovementSound()
    {
        if ((Xdirection != 0 || Zdirection != 0) && !audioSource.isPlaying&&Time.timeScale!=0)
        {
            audioSource.Play();
        }
        else if (Xdirection == 0 && Zdirection == 0 && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
