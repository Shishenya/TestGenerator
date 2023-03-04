using UnityEngine;
using TMPro;

public class OverviewPartPanelUI : MonoBehaviour
{
    const string title = "Обзор составной части: ";
    const string titleEmptyPart = "Выберите деталь для просмотра";

    [SerializeField] private TMP_Text _titleText;
    private OverviewPart _overviewPart;
    private GameObject _switchPartsPanel;

    // public static OverviewPartPanelUI Instance;

    /// <summary>
    /// загрузка ресурсов
    /// </summary>
    private void LoadResourves()
    {
        _overviewPart = ProjectResources.Instance.overviewPart;
        _switchPartsPanel = ProjectResources.Instance.switchPartPanel;
    }

    private void OnEnable()
    {
        LoadResourves();

        _overviewPart.showPartEvent += UpdateTitle;
        _overviewPart.hidePartEvent += UpdateTitle;
    }

    private void UpdateTitle(GameObject partGenetator)
    {
        if (partGenetator != null)
        {
            if (partGenetator.GetComponent<GeneratorPart>() != null)
            {
                string namePart = partGenetator.GetComponent<GeneratorPart>().generatorPartSO.namePart;
                _titleText.text = $"{title}{namePart}";
            }
        }
        else
        {
            _titleText.text = titleEmptyPart;
        }
    }

    /// <summary>
    /// Выход из состояния обзора отдельной части
    /// </summary>
    public void ReturnButtonClick()
    {
        _overviewPart.ReturnClick();
    }

}
