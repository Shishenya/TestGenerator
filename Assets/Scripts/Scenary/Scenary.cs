using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenary
{
    public ScenarySO scenarySO;
    public int currentStep = -1;

    public Scenary(ScenarySO currentScenary)
    {
        scenarySO = currentScenary;
        currentStep = 0;
    }

    /// <summary>
    /// Следующий шаг
    /// </summary>
    public void NextStep()
    {
        if (currentStep + 1 < scenarySO.stepsScenary.Length)
        {
            currentStep++;
        }
    }

}
