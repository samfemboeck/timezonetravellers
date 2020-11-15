using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    float currentx;
    float currenty;
    float lastx;
    float lasty;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        currentx = Input.GetAxisRaw("Horizontal");
        currenty = Input.GetAxisRaw("Vertical");
        animator.SetFloat("currentx", currentx);
        animator.SetFloat("currenty", currenty);
        Bounds spriteBounds = GetComponent<SpriteRenderer>().bounds;
        Vector3 move = new Vector3( currentx* Speed * Time.deltaTime, currenty * Speed * Time.deltaTime);
        Vector3 newPos = transform.position + move;
        Bounds newBounds = new Bounds(newPos, spriteBounds.size);
        if (Map.Instance.Encompasses(newBounds))
            transform.Translate(move);
        if (move.sqrMagnitude > 0)
        {
            lastx = currentx;
            lasty = currenty;
            animator.SetFloat("lastx", lastx);
            animator.SetFloat("lasty", lasty);
            animator.SetBool("walk", true);
        }
        else animator.SetBool("walk", false);
    }
}
