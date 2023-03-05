using UnityEngine;
using UnityEngine.UI;

public class AnimationScenaryService : MonoBehaviour
{
    [SerializeField] Animator _generatorAnimator;
    [SerializeField] Button _nextStepButton;
    private Scenary _scenary;

    public void ButtonClickShowAnimation()
    {
        _scenary = ProjectService.Instance.CurrentScenary;
        AnimationClip clip = _scenary.scenarySO.stepsScenary[_scenary.currentStep].clipRun;
        if (_generatorAnimator != null && clip != null)
        {
            _generatorAnimator.Play(clip.name);
        }

        if (this.gameObject.GetComponent<Button>() != null)
        {
            this.gameObject.GetComponent<Button>().interactable = false;
        }

        _nextStepButton.interactable = true;

    }
}
