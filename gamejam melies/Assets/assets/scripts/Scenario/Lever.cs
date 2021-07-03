using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    bool isInRange;
    [SerializeField] Animator textAnim;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInRange = true;
        textAnim.SetBool("On", true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isInRange = false;
        textAnim.SetBool("On", false);
    }

    private void Update()
    {
        if (isInRange)
        {
            if (Input.GetButtonDown("Use"))
            {
                spriteRenderer.flipX = !spriteRenderer.flipX;

            }
        }
    }
}
