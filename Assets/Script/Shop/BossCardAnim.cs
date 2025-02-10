using UnityEngine;

public class BossCardAnim : MonoBehaviour
{
    [SerializeField] Animator animator;
    private AnimatorOverrideController animatorOverrideController;
    [SerializeField] AnimationClip animationClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = animatorOverrideController;
        animatorOverrideController["BasicAttackAnim"] = animationClip;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
