using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScenaryStepPanelUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _titleStep;
    [SerializeField] private TMP_Text _descriptionText;
    [SerializeField] private GameObject _buttonNextStep;
    [SerializeField] private Button _showAnimationButton;


    private void OnEnable()
    {
        UpdatePanel();
    }

    /// <summary>
    /// Обновление информации в панели текущего шага
    /// </summary>
    public void UpdatePanel()
    {
        if (ProjectService.Instance.CurrentScenary != null)
        {
            Scenary scenary = ProjectService.Instance.CurrentScenary;
            ScenarySO scenarySO = scenary.scenarySO;
            int step = scenary.currentStep;

            UpdateText(step, scenarySO);
            CheckHasBeenNextStep(step, scenarySO);
            CheckHasBeenShowAnimation(step, scenarySO);
        }
    }

    /// <summary>
    /// Кнопка "следующий шаг (Дальше)"
    /// </summary>
    public void ClickButtonNextStep()
    {
        Scenary scenary = ProjectService.Instance.CurrentScenary;
        scenary.NextStep();
        UpdatePanel();
    }

    /// <summary>
    /// обновление текста в панели текущего шага
    /// </summary>
    private void UpdateText(int step, ScenarySO scenarySO)
    {
        if (step < scenarySO.stepsScenary.Length)
        {
            string title = scenarySO.stepsScenary[step].title;
            string description = scenarySO.stepsScenary[step].description;

            _titleStep.text = title;
            _descriptionText.text = description;
        }
        else
        {
            string error = "Error!";
            _titleStep.text = error;
            _descriptionText.text = error;
        }
    }

    /// <summary>
    /// Проверка на наличие следующего шага
    /// </summary>
    private void CheckHasBeenNextStep(int step, ScenarySO scenarySO)
    {
        if (step + 1 < scenarySO.stepsScenary.Length)
        {
            _buttonNextStep.SetActive(true);
        }
        else
        {
            _buttonNextStep.SetActive(false);
        }

    }

    /// <summary>
    /// Проверяет, можно ли показать анимацию
    /// </summary>
    private void CheckHasBeenShowAnimation(int step, ScenarySO scenarySO)
    {
        if (scenarySO.stepsScenary[step].clipRun == null)
        {
            _showAnimationButton.interactable = false;
        }
        else
        {
            _showAnimationButton.interactable = true;
        }
    }

}
