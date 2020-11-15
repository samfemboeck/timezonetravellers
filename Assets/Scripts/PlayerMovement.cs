using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public float currentspeed;
    float currentx;
    float currenty;
    float lastx;
    float lasty;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        currentspeed = Speed;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        currentx = Input.GetAxisRaw("Horizontal");
        currenty = Input.GetAxisRaw("Vertical");
        bool onlyone = (currenty == 0 || currentx == 0);
        if (onlyone)
        { 
        animator.SetFloat("currentx", currentx);
        animator.SetFloat("currenty", currenty);

        Vector3 move = new Vector3(currentx * Speed * Time.deltaTime, currenty * Speed * Time.deltaTime);


        Bounds spriteBounds = GetComponent<SpriteRenderer>().bounds;
        Vector3 newPos = transform.position + move;
        Bounds newBounds = new Bounds(newPos, spriteBounds.size);
        //if (Map.Instance.Encompasses(newBounds))
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
        else animator.SetBool("walk", false);
    }

   
    public void makespeedzero()
    {
        currentspeed = 0;
    }

    public void restoretooriginalspeed()
    {
        currentspeed = Speed;
    }
}
