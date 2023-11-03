using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tween
{
<<<<<<< HEAD
    public Transform Target { get; }
    public Vector3 StartPos { get; }
    public Vector3 EndPos { get; }
    public float StartTime { get; }
    public float Duration { get; }

    public Tween(Transform target, Vector3 startPos, Vector3 endPos, float startTime, float duration)
    {
        Target = target;
        StartPos = startPos;
        EndPos = endPos;
=======
    public Transform Target { get; private set; }
    public Vector3 StartPos { get; private set; }
    public Vector3 EndPos { get; private set; }
    public float StartTime { get; private set; }
    public float Duration { get; private set; }


    public Tween(Transform target, Vector3 origin, Vector3 destination, float startTime, float duration)
    {
        Target = target;
        StartPos = origin;
        EndPos = destination;
>>>>>>> pac-movement
        StartTime = startTime;
        Duration = duration;
    }
}
<<<<<<< HEAD

=======
>>>>>>> pac-movement
