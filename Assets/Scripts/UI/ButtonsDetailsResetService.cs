using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsDetailsResetService : MonoBehaviour
{

    [SerializeField] private Animator _generatorAnimator;
    [SerializeField] private AnimationClip _defaultGeneratorStateClip;

    /// <summary>
    /// Сброс сценария.Возвращаем все детали в исходное положение текущего сценария
    /// </summary>
    public void ClickButtonResetScenary()
    {
        AnimationClip clipDefault = ProjectService.Instance.CurrentScenary.scenarySO.defaultPosition;
        if (clipDefault != null && _generatorAnimator != null)
        {
            _generatorAnimator.Play(clipDefault.name);
        }
    }

    /// <summary>
    /// Возвращает детали генератора в исходное положение сборного состояния
    /// </summary>
    public void ClickButtonReturnDetailsInStartPositionDefault()
    {
        if (_defaultGeneratorStateClip != null && _generatorAnimator != null)
        {
            _generatorAnimator.Play(_defaultGeneratorStateClip.name);
        }
    }
}
