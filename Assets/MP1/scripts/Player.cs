using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    private bool _isMoved = false;
    private Vector3 _origin;
    public GameObject moveReference;
    public Light light;
    public GameObject leftController;
    public float cometSpeed = 5f;
    
    [SerializeField] private GameObject cometPrefab;
    
    // Quitting
    public InputActionReference inputAction1;
    
    // Moving out and inside
    public InputActionReference inputAction2;
    
    // Shooting & Spawning a comet
    public InputActionReference inputAction3;
    
    // Random Lighting Switching
    public InputActionReference inputAction4;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _origin = transform.position;
        
        inputAction1.action.Enable();
        inputAction2.action.Enable();
        inputAction3.action.Enable();
        inputAction4.action.Enable();

        if (inputAction1.action != null)
        {
            inputAction1.action.performed += Action1;
        }

        if (inputAction2.action != null)
        {
            inputAction2.action.performed += Action2;
        }

        if (inputAction3.action != null)
        {
            inputAction3.action.performed += Action3;
        }

        if (inputAction4.action != null)
        {
            inputAction4.action.performed += Action4;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void Move()
    {
        if (_isMoved)
        {
            transform.position = _origin;
            _isMoved = false;
        }
        else
        {
            transform.position = moveReference.transform.position;
            _isMoved = true;
        }
        
        GetComponent<AudioSource>().Play();
        GetComponent<ParticleSystem>().Play();
    }

    private void Action1(InputAction.CallbackContext context)
    {
        Application.Quit();
    }

    private void Action2(InputAction.CallbackContext context)
    {
        Move();
        Debug.Log("Moved");
    }
    
    private void Action3(InputAction.CallbackContext context)
    {
        
        if (leftController != null)
        {
            Vector3 direction = leftController.transform.forward;
            GameObject comet = Instantiate(cometPrefab, leftController.transform.position, Quaternion.LookRotation(direction));
            Comet cometScript = comet.GetComponent<Comet>();
            cometScript.speedDefined = true;
            comet.GetComponent<Comet>().velocity = direction * cometSpeed;
            leftController.GetComponent<ParticleSystem>().Play();
            leftController.GetComponent<AudioSource>().Play();
        }
    }
    
    private void Action4(InputAction.CallbackContext context)
    {
        light.GetComponent<PointLightScript>().ChangeColor();
    }
}
