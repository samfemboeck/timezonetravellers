using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public float currentspeed;
    Animator animator;
    bool _canWalk = true;

    public bool CanWalk
    {
        get => _canWalk;
        set
        {
            _canWalk = value;
            animator.SetBool("walk", value);
        }
    }
       

    // Start is called before the first frame update
    void Awake()
    {
        currentspeed = Speed;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!CanWalk)
            return;

        var move = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        if (move == Vector3.zero)
        {
            animator.SetBool("walk", false);
            return;
        }

        animator.SetBool("walk", true);
        animator.SetFloat("moveX", move.x);
        animator.SetFloat("moveY", move.y);
        transform.Translate(move * Speed * Time.deltaTime);
    }

    public void GoCorrupt()
    {
        animator.SetTrigger("corrupt");
        CanWalk = false;
    }

    private void OnEnable()
    {
        Debug.Log("enabling playermovement");
    }

    private void OnDisable()
    {
        Debug.Log("disabling playermovement");
    }
}
