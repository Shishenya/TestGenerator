using System.Collections;
using System.Collections.Generic;
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
    [Tooltip("GameObject Panel from projects")]
    #endregion
    public GameObject startPanel;
    public GameObject overviewPartPanel;
    public GameObject assemblyPanel;
    public GameObject switchPartPanel;
    public GameObject selectedPartPanel;


    #region Base Scripts
    [Space(10)]
    [Header("Base Scripts")]
    #endregion
    #region Tooltip
    [Tooltip("Base Scripts in projects")]
    #endregion
    public OverviewPart overviewPart;
    public CameraService cameraService;
    public MainCanvasUI mainCanvasUI;
    public SelectedPartUI selectedPartUI;
}
