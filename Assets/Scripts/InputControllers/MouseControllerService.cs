using UnityEngine;

public class MouseControllerService : InputContollerService
{
    private string description = "Для обзора детали зажмите ЛКМ. Для приближения/отдаления используете колесико";
    public override string descriptionInput => description;
    private float _lastPositionX;
    private float _minSecondPress = 0.15f;
    private float _currentSecondPress = 0f;
    private float _offsetPosition = 0.5f;

    private void Start()
    {
        _lastPositionX = Input.mousePosition.x;
    }

    public override void RotateGenerator()
    {
        if (Input.GetMouseButton(0))
        {
            _currentSecondPress += Time.deltaTime;

            if (_currentSecondPress > _minSecondPress)
            {

                if ((Input.mousePosition.x > _lastPositionX) && (Mathf.Abs(Input.mousePosition.x - _lastPositionX) > _offsetPosition))
                {
                    RorateRight();
                }
                else if ((Input.mousePosition.x < _lastPositionX) && (Mathf.Abs(Input.mousePosition.x - _lastPositionX) > _offsetPosition))
                {
                    RotateLeft();
                }
            }

        }

        if (Input.GetMouseButtonUp(0))
        {
            _currentSecondPress = 0f;
        }

        _lastPositionX = Input.mousePosition.x;
    }

    public override void ScrollCamera()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll != 0f)
        {
            float posZ = Mathf.Clamp(_cameraTransform.position.z + (scroll * _whellSpeed), _minZPosition, _maxZPosition);
            _cameraTransform.position = new Vector3(_cameraTransform.position.x, _cameraTransform.position.y, posZ);
        }
    }

    /// <summary>
    /// ПОворот на лево
    /// </summary>
    private void RotateLeft()
    {
        float horizontal = -1f;
        _generatorModel.transform.Rotate(0, _rotateSpeed * horizontal, 0);
    }

    /// <summary>
    /// Поворот направо
    /// </summary>
    private void RorateRight()
    {
        float horizontal = 1f;
        _generatorModel.transform.Rotate(0, _rotateSpeed * horizontal, 0);

    }

}
