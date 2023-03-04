using UnityEngine;

public class ProjectService : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private bool _scenaryRun = false;
    public bool ScenaryRun { get => _scenaryRun; }
    private Scenary _currentScenary = null;
    public Scenary CurrentScenary { get => _currentScenary; }

    private static ProjectService _instance;

    public static ProjectService Instance { get => _instance; }

    private void Awake()
    {
        _instance = this;
        _currentScenary = null;
    }

    /// <summary>
    /// Запуск нового сценария
    /// </summary>
    public void RunScenary(ScenarySO scenarySO)
    {
        _currentScenary = new Scenary(scenarySO);

        AnimationClip defaultClip = scenarySO.defaultPosition;
        if (defaultClip != null && _animator != null)
        {
            _animator.Play(defaultClip.name);
        }

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
