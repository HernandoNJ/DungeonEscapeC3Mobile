using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void SetSpeedFloat(float speedArg)
    {
        animator.SetFloat("speed", Mathf.Abs(speedArg));
    }

    public void SetJumpBool(bool jumpArg)
    {
        animator.SetBool("jumping", jumpArg);
    }
}

