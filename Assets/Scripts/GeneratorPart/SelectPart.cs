using UnityEngine;

public class SelectPart : MonoBehaviour
{
    [SerializeField] private Material _selectedMaterial = null;
    private Material _defaultMaterial;
    private bool _isSelected = false;

    private void Start()
    {
        _defaultMaterial = GetComponent<MeshRenderer>().material;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_isSelected)
            {
                GetComponent<MeshRenderer>().material = _defaultMaterial;
            }
            else
            {
                GetComponent<MeshRenderer>().material = _selectedMaterial;
            }
            _isSelected = !_isSelected;
        }
    }
}
