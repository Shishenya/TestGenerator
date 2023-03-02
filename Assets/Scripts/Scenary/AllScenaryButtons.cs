using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllScenaryButtons : MonoBehaviour
{
    [SerializeField] private GameObject scenaryButton;
    private bool _isCreated = false;

    private void OnEnable()
    {
        if (!_isCreated)
        {
            CreateScenaryButtons();
            _isCreated = true;
        }
    }

    private void CreateScenaryButtons()
    {
        foreach (ScenarySO scenary in ProjectResources.Instance.scenaries)
        {
            GameObject button = Instantiate(scenaryButton, this.gameObject.transform);
            if (button.GetComponent<ScenaryButton>()!=null)
            {
                button.GetComponent<ScenaryButton>().InitButton(scenary);
            }
        }
    }
}
