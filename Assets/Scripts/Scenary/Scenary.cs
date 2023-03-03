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

}
