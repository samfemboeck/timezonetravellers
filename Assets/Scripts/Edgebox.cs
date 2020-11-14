using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edgebox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.GetComponent<Balloon>())
            collision.gameObject.GetComponent<Balloon>().onedge = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
      
        if(collision.gameObject.GetComponent<Balloon>())
        collision.gameObject.GetComponent<Balloon>().onedge = true;
    }
}
