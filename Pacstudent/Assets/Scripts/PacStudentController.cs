using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    private Tweener tweener;
    [SerializeField] private float time = 0.1F;
    public bool isWallColl = true;
    public LayerMask Wall;
    private KeyCode LastInput;
    private KeyCode CurrentInput;
    Vector3 startpos;
    private Animator animator;
    private AudioSource movementAudio;
    private AudioSource wallAudio;
    private ParticleSystem dustEffect;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        tweener = GetComponent<Tweener>();
        AudioSource[] audioSources = GetComponents<AudioSource>();
        movementAudio = audioSources[0];
        wallAudio = audioSources[1];
        startpos = transform.position;
    }

    void Update()
    {
        PlayerInput();
        isMove();
    }
    private void PlayerInput()
    {
        if (Input.GetKey(KeyCode.W))
            CurrentInput = KeyCode.W;
        if (Input.GetKey(KeyCode.S))
            CurrentInput = KeyCode.S;
        if (Input.GetKey(KeyCode.A))
            CurrentInput = KeyCode.A;
        if (Input.GetKey(KeyCode.D))
            CurrentInput = KeyCode.D;

    }

    private void isMove()
    {
        animator.SetBool("Up", false);
        animator.SetBool("Down", false);
        animator.SetBool("Right", false);
        animator.SetBool("Left", false);
        switch (CurrentInput)
        {
            case KeyCode.W:
                if (IsWalk(CurrentInput))
                {

                    animator.SetBool("Up", true);
                    Move();
                }
                else
                {
                    movementAudio.Stop();
                    if (isWallColl == true)
                    {
                        isWallColl = false;
                        wallAudio.Play();
                    }

                    tweener.EndTween(transform);
                }

                break;

            case KeyCode.A:
                if (IsWalk(CurrentInput))
                {

                    animator.SetBool("Left", true);
                    Move();
                }
                else
                {
                    movementAudio.Stop();
                    if (isWallColl == true)
                    {
                        isWallColl = false;
                        wallAudio.Play();
                    }
                    tweener.EndTween(transform);
                }

                break;

            case KeyCode.S:
                if (IsWalk(CurrentInput))
                {
                    animator.SetBool("Down", true);
                    Move();
                }
                else
                {
                    movementAudio.Stop();
                    if (isWallColl == true)
                    {
                        isWallColl = false;
                        wallAudio.Play();
                    }
                    tweener.EndTween(transform);
                }

                break;

            case KeyCode.D:
                if (IsWalk(CurrentInput))
                {
                    animator.SetBool("Right", true);
                    Move();

                }
                else
                {
                    movementAudio.Stop();
                    if (isWallColl == true)
                    {
                        isWallColl = false;
                        wallAudio.Play();
                    }
                    tweener.EndTween(transform);
                }

                break;
        }
    }
    private void Move()
    {
        if (!movementAudio.isPlaying)
            movementAudio.Play();
        isWallColl = true;
        tweener.AddTween(transform, transform.position, CurrentPoint, time);
    }
    Vector3 direction;
    Vector3 CurrentPoint;
    bool IsArrawy = false;
    bool IsWalk(KeyCode currentInput)
    {
        switch (currentInput)
        {
            case KeyCode.W:
                direction = transform.up;
                break;
            case KeyCode.S:
                direction = -transform.up;
                break;
            case KeyCode.A:
                direction = -transform.right;
                break;
            case KeyCode.D:
                direction = transform.right;
                break;
        }

        LastInput = CurrentInput;
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, direction, 1.1F, Wall);
        if (hit2D)
        {
            if (hit2D.collider.gameObject)
            {

                return false;
            }

        }

        if (Vector3.Distance(transform.position, (transform.position + direction)) > 0 && IsArrawy == false)
        {

            CurrentPoint = transform.position + direction;
            IsArrawy = true;
        }
        if (Vector3.Distance(transform.position, CurrentPoint) == 0)
        {
            IsArrawy = false;
        }
        if (Vector3.Distance(transform.position, (transform.position + direction)) > 0 && IsArrawy == false)
        {

            CurrentPoint = transform.position + direction;
            IsArrawy = true;
        }

        return true;
    }


}