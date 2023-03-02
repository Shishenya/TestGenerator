using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    private void Start()
    {        
        LoadStartPanel();
    }

    /// <summary>
    /// Загрузка стартовой панели
    /// </summary>
    private void LoadStartPanel()
    {
        ProjectResources.Instance.startPanel.SetActive(true);
        ProjectResources.Instance.overviewPartPanel.SetActive(false);
        ProjectResources.Instance.assemblyPanel.SetActive(false);
        ProjectResources.Instance.switchPartPanel.SetActive(false);
        ProjectResources.Instance.selectedPartPanel.SetActive(false);
    }
}
