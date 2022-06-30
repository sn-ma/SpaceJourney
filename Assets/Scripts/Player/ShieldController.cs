using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ShieldController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void StartFadeAnimation()
    {
        animator.SetTrigger("Hit");
    }
}
