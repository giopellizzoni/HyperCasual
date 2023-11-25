using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    public List<AnimatorSetup> animatorSetups;

    public Animator animator;
 
    internal void Play(AnimationType type, float currentSpeedFactor = 1f)
    {
        var animation = animatorSetups.Where(i => i.type == type).FirstOrDefault();
        animator.SetTrigger(animation.trigger);
        animator.speed = animation.speed * currentSpeedFactor * Time.deltaTime;
        
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
    public float speed = 1f;
}