using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PartGeneratorClickAnimation : MonoBehaviour
{
    [SerializeField] AnimationScenaryService _animationScenaryService;
    private SwitcherStateService _switcherStateService;
    private GeneratorPartSO _currentGeneratorPartSO;

    private void Start()
    {
        LoadResources();
        _currentGeneratorPartSO = GetCurrentGeneratorPartSO();
    }
    private void LoadResources()
    {
        _switcherStateService = ProjectResources.Instance.switcherStateService;
    }
    private void OnMouseDown()
    {
        if (_switcherStateService.GetState() != State.RunScenary) return;

        GeneratorPartSO[] partsInCurrentStep = GetCurrentGeneratorPartsArrayInStep();
        if (partsInCurrentStep != null)
        {
            bool anyPart = partsInCurrentStep.Any(element => element == _currentGeneratorPartSO);
            // Debug.Log("результат: " + anyPart);
            if (_animationScenaryService != null && anyPart)
            {
                _animationScenaryService.ButtonClickShowAnimation();
            }
        }
    }

    /// <summary>
    /// Получает текущее представление по детали генератора
    /// </summary>
    private GeneratorPartSO GetCurrentGeneratorPartSO()
    {
        if (gameObject.GetComponent<GeneratorPart>() != null)
        {
            return gameObject.GetComponent<GeneratorPart>().generatorPartSO;
        }
        return null;
    }


    /// <summary>
    /// Возвращает массив деталей (их описаний) из текущего шага сценария
    /// </summary>
    private GeneratorPartSO[] GetCurrentGeneratorPartsArrayInStep()
    {
        int step = ProjectService.Instance.CurrentScenary.currentStep;
        if (step < ProjectService.Instance.CurrentScenary.scenarySO.stepsScenary.Length)
        {
            GeneratorPartSO[] partsInCurrentStep = ProjectService.Instance.CurrentScenary.scenarySO.stepsScenary[step].needPartClickToClipShow;
            return partsInCurrentStep;
        }
        return null;

    }
}
