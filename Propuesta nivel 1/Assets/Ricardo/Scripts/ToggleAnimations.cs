
using UnityEngine;

public class ToggleAnimations : MonoBehaviour
{
    [SerializeField] Animator anim;
    private string currentState;
   
    public void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        anim.Play(newState);

        currentState = newState;
    }
}
