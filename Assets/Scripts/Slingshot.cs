using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public GameObject StonePrefab;
    public GameEvent OnSlingshot;
    Vector3 _initialMousePos;
    Animator animator;

    bool charging=false;

    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _initialMousePos = Input.mousePosition;
            animator.SetTrigger("charge");
            charging = true;
        }
      
        if (Input.GetMouseButtonUp(0))
        {
            if (_initialMousePos != Input.mousePosition)
            {
                animator.SetTrigger("shoot");
               
            }
            animator.SetTrigger("default");
        }

    }
    public void turnofftriggers()
    {
        animator.SetBool("shoot", false);
        animator.SetBool("default", false);
    }

    public void createrock()
    {
        OnSlingshot.Raise();
        GameObject stone = Instantiate(StonePrefab, transform.position, Quaternion.identity);
        stone.GetComponent<Stone>().Direction = (_initialMousePos - Input.mousePosition).normalized;
    }
}
