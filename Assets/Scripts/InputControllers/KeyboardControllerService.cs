using UnityEngine;

public class KeyboardControllerService : InputContollerService
{

    private string description = "��� �������� ���������� ����������� ������� '����� (A)' � '������ (D)'." +
        "��� ����������� � ��������� ����������� �������� �����."; // �������� ����������

    public override string descriptionInput { get => description; }

    /// <summary>
    /// ����������� � ���������
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
    /// ������� ���������� � ��� ������
    /// </summary>
    public override void RotateGenerator()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0f)
        {
            _generatorModel.transform.Rotate(0, _rotateSpeed * horizontal, 0);
        }        
    }
}
