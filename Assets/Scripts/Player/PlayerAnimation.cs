using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayAnimation(string animationName)
    {
        animator.Play(animationName);
    }

    public void StopAllAnimations()
    {
        animator.Rebind(); 
        animator.Update(0f);
    }
}
