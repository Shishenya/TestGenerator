using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPartPanelUI : MonoBehaviour
{
    [SerializeField] private OverviewPart _overviewPart;
    [SerializeField] private GameObject _buttonPart;
    [SerializeField] private GameObject _buttonsParent;

    private bool _isCreated = false;

    private void OnEnable()
    {
        CreateAllPartsButtons();
        _isCreated = true;
    }


    /// <summary>
    /// Создание кнопок для составных частей
    /// </summary>
    private void CreateAllPartsButtons()
    {

        if (_isCreated) return;

        _buttonPart.SetActive(false);

        foreach (GeneratorPart generatorPart in _overviewPart.GeneratorParts)
        {
            GameObject currentButton = Instantiate(_buttonPart, _buttonsParent.transform);

            if (currentButton.GetComponent<ButtonSwitchPart>()!=null)
            {
                currentButton.GetComponent<ButtonSwitchPart>().InitButton(generatorPart);
                currentButton.SetActive(true);
            }

        }
    }
    
}
