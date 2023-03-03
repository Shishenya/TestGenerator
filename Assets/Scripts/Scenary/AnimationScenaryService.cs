using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScenaryService : MonoBehaviour
{
    [SerializeField] Animator _generatorAnimator;
    private Scenary _scenary;

    public void ButtonClickShowAnimation()
    {
        _scenary = ProjectService.Instance.CurrentScenary;
        AnimationClip clip = _scenary.scenarySO.stepsScenary[_scenary.currentStep].clipRun;
        if (_generatorAnimator != null && clip != null)
        {
            _generatorAnimator.Play(clip.name);
        } 
    }
}
