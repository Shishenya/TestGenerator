using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HybridControllerService : InputContollerService
{
    private string description = "Для вращения генератора используете клавиши 'Влево (A)' и 'Вправо (D)' или средную кнопку мыши." +
       "Для приближение и отдаления используете колесико мышки."; // описание управления

    public override string descriptionInput { get => description; }

    private float _lastPositionX;
    private float _minSecondPress = 0.15f;
    private float _currentSecondPress = 0f;
    private float _offsetPosition = 0.5f;

    /// <summary>
    /// Приближение и отдаление
    /// </summary>
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
    /// Поворот генератора и его частей
    /// </summary>
    public override void RotateGenerator()
    {
        RotateGeneratorMouse();
        RotateGeneratorKeyboard();
    }

    private void RotateGeneratorMouse()
    {
        if (Input.GetMouseButton(2))
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

        if (Input.GetMouseButtonUp(2))
        {
            _currentSecondPress = 0f;
        }

        _lastPositionX = Input.mousePosition.x;
    }

    private void RotateGeneratorKeyboard()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0f)
        {
            _generatorModel.transform.Rotate(0, _rotateSpeed * horizontal, 0);
        }
    }

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
