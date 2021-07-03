using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScenario2 : MonoBehaviour
{
    public bool canInteract = false;

    public Animator anim;
    public int rotation = 3;

    int counter = 0;
    bool delayEnded = true;

    void Update()
    {
        if (Input.GetButtonDown("Use") && canInteract && delayEnded)
        {
            rotation += 1;
            anim.SetFloat("rotation", rotation);
            if (rotation >= 4)
                rotation = 0;
            delayEnded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canInteract = false;
        }
    }
    public void endDelay() { delayEnded = true; }

    public void reset()
    {
        rotation = 3;
        anim.SetFloat("rotation", rotation);
        delayEnded = true;
    }
}
