using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlls : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Animator anim = GetComponent<Animator>();



        // Get a list of the animation clips
        AnimationClip[] animationClips = anim.runtimeAnimatorController.animationClips;

        // Iterate over the clips and gather their information
        foreach (AnimationClip animClip in animationClips)
        {
            Debug.Log(animClip.name + ": " + animClip.length);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
