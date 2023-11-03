using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweener : MonoBehaviour
{
<<<<<<< HEAD

    private List<Tween> activeTweens = new List<Tween>();

    void Start()
    {

=======
    //private Tween activeTween;
    private List<Tween> activeTweens;

    void Start()
    {
        activeTweens = new List<Tween>();
>>>>>>> pac-movement
    }

    void Update()
    {
<<<<<<< HEAD
        FrameCalculation();

    }
    public void FrameCalculation()
    {
        for (int i = 0; i < activeTweens.Count; i++)
        {
            Tween activeTween = activeTweens[i];
            if ((activeTween.Target.position - activeTween.EndPos).sqrMagnitude > 0.1f)
            {
                float ResultTime = (Time.time - activeTween.StartTime) / activeTween.Duration;
                activeTween.Target.position = Vector3.Lerp(activeTween.StartPos, activeTween.EndPos, ResultTime);
=======
        //if (activeTween != null)
        Tween activeTween;
        for (int i = activeTweens.Count - 1; i >= 0; i--) //Tween activeTween in activeTweens.Reverse<Tween>())
        {
            activeTween = activeTweens[i];

            if (Vector3.Distance(activeTween.Target.position, activeTween.EndPos) > 0.1f)
            {
                float timeFraction = (Time.time - activeTween.StartTime) / activeTween.Duration;
                timeFraction = Mathf.Pow(timeFraction, 3);
                activeTween.Target.position = Vector3.Lerp(activeTween.StartPos,
                                                          activeTween.EndPos,
                                                           timeFraction);
>>>>>>> pac-movement
            }
            else
            {
                activeTween.Target.position = activeTween.EndPos;
<<<<<<< HEAD
                activeTweens.Remove(activeTween);
            }
        }
    }
    public bool TweenExists(Transform target)
    {
        for (int i = 0; i < activeTweens.Count; i++)
            if (activeTweens[i].Target == target)
                return true;
        return false;
    }
    public bool AddTween(Transform targetObject, Vector3 startPos, Vector3 endPos, float duration)
    {
        if (TweenExists(targetObject) == false)
=======
                //activeTween = null;
                activeTweens.RemoveAt(i);
            }
        }
    }

    public bool AddTween(Transform targetObject, Vector3 startPos, Vector3 endPos, float duration)
    {
        if (!TweenExists(targetObject))
>>>>>>> pac-movement
        {
            activeTweens.Add(new Tween(targetObject, startPos, endPos, Time.time, duration));
            return true;
        }
        return false;
    }

<<<<<<< HEAD
    public void StopTween(Transform target)
=======

    public bool TweenExists(Transform target)
    {
        foreach (Tween activeTween in activeTweens)
        {
            if (activeTween.Target.transform == target)
                return true;
        }
        return false;
    }

    public void EndTween(Transform target)
>>>>>>> pac-movement
    {
        Tween targetTween = null;
        foreach (Tween t in activeTweens)
        {
            if (t.Target == target)
            {
                targetTween = t;
            }
        }
<<<<<<< HEAD
        if (targetTween != null) activeTweens.Remove(targetTween);
    }
}
=======
        if(targetTween != null) activeTweens.Remove(targetTween);
    }
}

>>>>>>> pac-movement
