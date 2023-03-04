using UnityEngine;

public abstract class InputContollerService : MonoBehaviour
{
    [SerializeField] private protected GameObject _generatorModel;
    [SerializeField] private protected float _whellSpeed = 10f;
    [SerializeField] private protected float _minZPosition = -10f;
    [SerializeField] private protected float _maxZPosition = -2;
    [SerializeField] private protected float _rotateSpeed = 1f;
    private protected Transform _cameraTransform;

    public abstract string descriptionInput { get; } // описание управления

    private void Awake()
    {
        _cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        ScrollCamera();
        RotateGenerator();
    }

    public abstract void ScrollCamera(); // приближение и отдаление
    public abstract void RotateGenerator(); // поворот генератора

}
