using UnityEngine;

public class CameraService : MonoBehaviour
{
    [SerializeField] private GameObject _generatorModel;
    [SerializeField] private float _whellSpeed = 10f;
    [SerializeField] private float _minZPosition = -10f;
    [SerializeField] private float _maxZPosition = -2;
    [SerializeField] private float _rotateSpeed = 1f;
    private Transform _cameraTransform;

    private void Awake()
    {
        _cameraTransform = Camera.main.transform;
    }

    private void Start()
    {        
        //Debug.Log(ProjectResources.Instance.startPanel.name);
    }

    private void Update()
    {
        ScrollCamera();
        RotateGenerator();
    }

    /// <summary>
    /// Приближение и отдаление
    /// </summary>
    private void ScrollCamera()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll != 0f)
        {
            float posZ = Mathf.Clamp(_cameraTransform.position.z + (scroll * _whellSpeed), _minZPosition, _maxZPosition);
            _cameraTransform.position = new Vector3(_cameraTransform.position.x, _cameraTransform.position.y, posZ);
        }
    }

    /// <summary>
    /// Поворот генератора и его частей
    /// </summary>
    private void RotateGenerator()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0f)
        {
            _generatorModel.transform.Rotate(0, _rotateSpeed * horizontal, 0);
        }
    }
}
