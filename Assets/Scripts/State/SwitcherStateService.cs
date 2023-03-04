using UnityEngine;

public class SwitcherStateService : MonoBehaviour
{
    private State _currentState;

    public void SetState(State state)
    {
        _currentState = state;
    }

    public State GetState()
    {
        return _currentState;
    }
}
