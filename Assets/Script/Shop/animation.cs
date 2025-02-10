using UnityEngine;

public class animation : MonoBehaviour

{
    public Animator animator;
    public Animation anim; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      animator = GetComponent<Animator>();  
    }

    // Update is called once per frame
   void PlayAnimation()
   {
    anim.Play("AnimationName");
   }
}
