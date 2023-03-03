using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OverviewPart : MonoBehaviour
{
    [SerializeField] private GeneratorPart[] _generatorParts;
    public GeneratorPart[] GeneratorParts { get => _generatorParts; }

    private SelectedPartUI _selectedPartUI;
    private MainCanvasUI _mainCanvasUI;
    public SwitcherStateService _switcherStateService;

    public GameObject currentViewPart = null;

    public event Action<GameObject> showPartEvent;
    public event Action<GameObject> hidePartEvent;

    private void Start()
    {
        LoadResources();
    }
    private void LoadResources()
    {
        _selectedPartUI = ProjectResources.Instance.selectedPartUI;
        _mainCanvasUI = ProjectResources.Instance.mainCanvasUI;
        _switcherStateService = ProjectResources.Instance.switcherStateService;
    }

    /// <summary>
    /// Убирает свободный обзор всех составных частей генератора 
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
    /// Устанавливает активную составную часть генератора
    /// </summary>
    public void OverviewCurrentEnablePart()
    {
        DisableAllParts();
        currentViewPart.GetComponent<GeneratorPart>().isOverviewPart = true;
        ShowCurrentPart();
        showPartEvent?.Invoke(currentViewPart);
    }

    /// <summary>
    /// Показывает конкретную составную часть генератора
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

    private void Update()
    {
        TestUpdate();
    }

    private void TestUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            ReturnClick();
        }

        if (Input.GetKeyDown(KeyCode.PageUp))
        {
            OverviewCurrentEnablePart();
            // ShowCurrentPart();
        }

    }

    public void ReturnClick()
    {
        EnableAllParts();
        ShowCurrentPart();
        currentViewPart = null;
        hidePartEvent?.Invoke(null);

        // Определяем состяоние возврата исходя из запущен ли сценарий
        State returnState = (ProjectService.Instance.ScenaryRun)? State.RunScenary: State.NonRunScenary;
        _switcherStateService.SetState(returnState);
        _mainCanvasUI.ShowPanelsByState();
    }

}
