using UnityEngine;
using System;

public class OverviewPart : MonoBehaviour
{
    [SerializeField] private GeneratorPart[] _generatorParts;
    public GeneratorPart[] GeneratorParts { get => _generatorParts; }

    private MainCanvasUI _mainCanvasUI;
    private SwitcherStateService _switcherStateService;

    [HideInInspector] public GameObject currentViewPart = null;

    public event Action<GameObject> showPartEvent;
    public event Action<GameObject> hidePartEvent;

    private void Start()
    {
        LoadResources();
    }
    private void LoadResources()
    {
        _mainCanvasUI = ProjectResources.Instance.mainCanvasUI;
        _switcherStateService = ProjectResources.Instance.switcherStateService;
    }

    /// <summary>
    /// ������� ��������� ����� ���� ��������� ������ ���������� 
    /// </summary>
    private void DisableAllParts()
    {
        foreach (GeneratorPart generatorPart in _generatorParts)
        {
            generatorPart.isOverviewPart = false;
        }
    }

    private void EnableAllParts()
    {
        foreach (GeneratorPart generatorPart in _generatorParts)
        {
            generatorPart.isOverviewPart = true;
        }
    }

    /// <summary>
    /// ������������� �������� ��������� ����� ����������
    /// </summary>
    public void OverviewCurrentEnablePart()
    {
        DisableAllParts();
        currentViewPart.GetComponent<GeneratorPart>().isOverviewPart = true;
        ShowCurrentPart();
        showPartEvent?.Invoke(currentViewPart);
    }

    /// <summary>
    /// ���������� ���������� ��������� ����� ����������
    /// </summary>
    private void ShowCurrentPart()
    {
        foreach (GeneratorPart generatorPart in _generatorParts)
        {
            if (generatorPart.isOverviewPart)
            {
                generatorPart.gameObject.SetActive(true);
            }
            else
            {
                generatorPart.gameObject.SetActive(false);
            }
        }
    }

    /// <summary>
    /// ������ �������� � �������� ��������
    /// </summary>
    public void ReturnClick()
    {
        EnableAllParts();
        ShowCurrentPart();
        currentViewPart = null;
        hidePartEvent?.Invoke(null);

        // ���������� ��������� �������� ������ �� ������� �� ��������
        State returnState = (ProjectService.Instance.ScenaryRun)? State.RunScenary: State.NonRunScenary;
        _switcherStateService.SetState(returnState);
        _mainCanvasUI.ShowPanelsByState();
    }

}
