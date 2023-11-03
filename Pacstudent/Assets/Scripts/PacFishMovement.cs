using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacFishMovement : MonoBehaviour
{
    public List<Transform> nextpoint;
    public Animator swim;
    [SerializeField] private float MoveSpeed = 3f;
    int index = 0;
    private Tweener tweener;

    void Start()
    {
        tweener = GetComponent<Tweener>();
        tweener.AddTween(transform, transform.position, nextpoint[index].position, MoveSpeed);
    }

    void Update()
    {
        PacfishControl();
    }
    public void PacfishControl()
    {
        if (Vector3.Distance(transform.position, nextpoint[index].position) == 0)
        {
            index++;

            if (index > 3)
                index = index % 4;
            switch (index)
            {
                case 0:
                    swim.SetTrigger("Right");
                    break;
                case 1:
                    swim.SetTrigger("Down");
                    break;
                case 2:
                    swim.SetTrigger("Left");
                    break;
                case 3:
                    swim.SetTrigger("Up");
                    break;
            }
            tweener.AddTween(transform, transform.position, nextpoint[index].position, MoveSpeed);
        }
    }
}
