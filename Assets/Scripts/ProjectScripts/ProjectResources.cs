using UnityEngine;

public class ProjectResources : MonoBehaviour
{
    public static ProjectResources Instance;

    private void Awake()
    {
        Instance = this;
    }

    #region GameObject Panel
    [Space(10)]
    [Header("GameObject Panel")]
    #endregion
    #region Tooltip
    [Tooltip("GameObjects Panels from project")]
    #endregion
    public GameObject startPanel;
    public GameObject overviewPartPanel;
    public GameObject assemblyPanel;
    public GameObject switchPartPanel;
    public GameObject selectedPartPanel;
    public GameObject selectedScenaryPanel;
    public GameObject scenaryPanel;


    #region Base Scripts
    [Space(10)]
    [Header("Base Scripts")]
    #endregion
    #region Tooltip
    [Tooltip("Base Scripts in project")]
    #endregion
    public OverviewPart overviewPart;
    public InputContollerService inputContollerService;
    public MainCanvasUI mainCanvasUI;
    public SelectedPartUI selectedPartUI;
    public SwitcherStateService switcherStateService;   

    #region Material
    [Space(10)]
    [Header("Material")]
    #endregion
    #region Tooltip
    [Tooltip("Material in project")]
    #endregion
    public Material selectedPartMaterial;

    #region Material
    [Space(10)]
    [Header("Scenaries")]
    #endregion
    #region Tooltip
    [Tooltip("Scenaries in project")]
    #endregion
    public ScenarySO[] scenaries;
}
