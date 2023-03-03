using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectService : MonoBehaviour
{
    private bool _scenaryRun = false;
    public bool ScenaryRun { get => _scenaryRun; }
    private Scenary _currentScenary;
    public Scenary CurrentScenary { get => _currentScenary; }

    private static ProjectService _instance;

    public static ProjectService Instance { get => _instance; }

    private void Awake()
    {
        _instance = this;
    }

    /// <summary>
    /// Запуск нового сценария
    /// </summary>
    public void RunScenary(ScenarySO scenarySO)
    {
        _currentScenary = new Scenary(scenarySO);
        _scenaryRun = true;
    }

    /// <summary>
    /// Сброс сценария
    /// </summary>
    public void ResetScenary()
    {
        _currentScenary = null;
        _scenaryRun = false;
    }
}
