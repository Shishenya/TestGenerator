using System.Linq;
using UnityEngine;

public class SwitchPartPanelUI : MonoBehaviour
{
    private OverviewPart _overviewPart;
    [SerializeField] private GameObject _buttonPart;
    [SerializeField] private GameObject _buttonsParent;

    private bool _isCreated = false;

    private void LoadResources()
    {
        _overviewPart = ProjectResources.Instance.overviewPart;
    }

    private void OnEnable()
    {
        LoadResources();

        CreateAllPartsButtons();       
    }


    /// <summary>
    /// Создание кнопок для составных частей
    /// </summary>
    private void CreateAllPartsButtons()
    {

        if (_isCreated) return;

        _buttonPart.SetActive(false);
        var sortParts = _overviewPart.GeneratorParts.OrderBy(element => element.generatorPartSO.namePart);

        foreach (GeneratorPart generatorPart in sortParts)
        {
            GameObject currentButton = Instantiate(_buttonPart, _buttonsParent.transform);

            if (currentButton.GetComponent<ButtonSwitchPart>()!=null)
            {
                currentButton.GetComponent<ButtonSwitchPart>().InitButton(generatorPart);
                currentButton.SetActive(true);
            }

        }

        _isCreated = true;
    }
    
}
