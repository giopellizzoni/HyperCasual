using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    public List<AnimatorSetup> animatorSetups;

    public Animator animator;
 

    public float animationTransition = .1f;

    internal void Play(AnimationType type)
    {
        var setup = animatorSetups.Where(i => i.type == type).FirstOrDefault();
        animator.SetTrigger(setup.trigger);
        
    }

    public enum AnimationType
    {
        RUN,
        IDLE, 
        DEATH
    }
}

[System.Serializable]
public class AnimatorSetup
{

    public AnimatorManager.AnimationType type;
    public string trigger;
}