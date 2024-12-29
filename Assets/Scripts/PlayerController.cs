using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 2.5f;
    [SerializeField] private float _mouseSensitivity = 3.0f;
    public GameManager _gameManager = null;

    private float _horizontal = 0.0f;
    private float _vertical = 0.0f;
    private float _mouseX = 0.0f;
    private float _mouseY = 0.0f;
    private float _xRotation = 0.0f;
    private float _yRotation = 0.0f;
    private Rigidbody _rigidbody = null;
    InputAction moveAction;
    InputAction lookAction;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _xRotation = _rigidbody.transform.localEulerAngles.x;
        _yRotation = _rigidbody.transform.localEulerAngles.y;
    }

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        lookAction = InputSystem.actions.FindAction("Look");
    }

    void Update()
    {
        if (!_gameManager.IsPaused)
        {
            Vector2 moveValue = moveAction.ReadValue<Vector2>();
            Vector2 lookValue = lookAction.ReadValue<Vector2>();

            _horizontal = moveValue.x;
            _vertical = moveValue.y;

            _mouseX = lookValue.x * _mouseSensitivity * Time.deltaTime;
            _mouseY = lookValue.y * _mouseSensitivity * Time.deltaTime;

            _xRotation -= _mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -90f, 90f); // Begrenzung der vertikalen Rotation

            _yRotation += _mouseX;

            _rigidbody.transform.localRotation = Quaternion.Euler(
                 _xRotation, 
                 _yRotation, 0f);
        }
    }

    private void FixedUpdate()
    {
        if (!_gameManager.IsPaused)
        {
            Vector3 movement = new Vector3(_horizontal, 0.0f, _vertical) * _speed;
            _rigidbody.linearVelocity = transform.TransformDirection(movement);
        }
    }
}
