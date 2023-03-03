using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScenaryStepPanelUI : MonoBehaviour
{
    [SerializeField] private TMP_Text titleStep;
    [SerializeField] private TMP_Text descriptionText;
    [SerializeField] private GameObject buttonNextStep;


    private void OnEnable()
    {
        UpdatePanel();
    }

    /// <summary>
    /// ���������� ���������� � ������ �������� ����
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
        }
    }

    /// <summary>
    /// ������ "��������� ��� (������)"
    /// </summary>
    public void ClickButtonNextStep()
    {
        Scenary scenary = ProjectService.Instance.CurrentScenary;
        scenary.NextStep();
        UpdatePanel();
    }

    /// <summary>
    /// ���������� ������ � ������ �������� ����
    /// </summary>
    private void UpdateText(int step, ScenarySO scenarySO)
    {
        if (step < scenarySO.stepsScenary.Length)
        {
            string title = scenarySO.stepsScenary[step].title;
            string description = scenarySO.stepsScenary[step].description;

            titleStep.text = title;
            descriptionText.text = description;
        }
        else
        {
            string error = "Error!";
            titleStep.text = error;
            descriptionText.text = error;
        }
    }

    /// <summary>
    /// �������� �� ������� ���������� ����
    /// </summary>
    private void CheckHasBeenNextStep(int step, ScenarySO scenarySO)
    {
        if (step + 1 < scenarySO.stepsScenary.Length)
        {
            buttonNextStep.SetActive(true);
        }
        else
        {
            buttonNextStep.SetActive(false);
        }

    }

}
