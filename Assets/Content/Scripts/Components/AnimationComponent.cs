using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationComponent : AComponent
{
    private AnimationClip currentAnimation;
    private float animationSpeed = 1f;
    private Animator animator;

    private bool isPaused = false;
    private bool isLooped = false;
    private bool isInObservationMode = false;
    public override void Initialize()
    {
        if (gameObject)
        {
            animator = GetComponent<Animator>();
            if (animator == null)
            {
                Debug.LogError("Animator Component not found !");
                return;
            }
        }
    }

    private AnimationClip GetAnimationClipByName(string animationName)
    {
        foreach (var clip in animator.runtimeAnimatorController.animationClips)
        {
            if (clip.name == animationName)
            {
                return clip;
            }
        }
        return null;
    }

    public void SetCurrentAnimation(string animationName)
    {
        currentAnimation = GetAnimationClipByName(animationName);
    }

    public void PlayAnimation()
    {
        if (currentAnimation != null)
        {
            currentAnimation.wrapMode = WrapMode.Loop;
        }
    }

    public void Pause()
    {
        isPaused = true;
        animator.speed = 0;
    }

    public void Resume()
    {
        isPaused = false;
        animator.speed = animationSpeed;
    }

    public void SetLoop(bool loop)
    {
        isLooped = loop;
        if (currentAnimation != null)
        {
            currentAnimation.wrapMode = isLooped ? WrapMode.Loop : WrapMode.Once;
        }
    }

    public void SetSpeed(float factor)
    {
        animationSpeed *= factor;
        if (!isPaused)
        {
            animator.speed = animationSpeed;
        }
    }


    public int GetCurrentFrame()
    {
        AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0);
        float animationTime = currentState.normalizedTime * currentState.length;
        int currentTime = Mathf.FloorToInt(animationTime * currentAnimation.frameRate);
        return currentTime;
    }

    public void SetCurrentTime(float timeInSeconds)
    {
        float animationLength = currentAnimation.length;
        float frameRate = currentAnimation.frameRate;

        timeInSeconds = Mathf.Clamp(timeInSeconds, 0, animationLength);

        float normalisedTime = timeInSeconds / animationLength;

        animator.Play(currentAnimation.name, 0, normalisedTime);
        animator.speed = isPaused ? 0 : animationSpeed;
    }

    public bool IsInObservationMode()
    {
        return isInObservationMode;
    }

    public void SetObservationMode(bool observationMode)
    {
        isInObservationMode = observationMode;
    }

    public float GetFrameRate()
    {
        return currentAnimation != null ? currentAnimation.frameRate : 0;
    }
}
