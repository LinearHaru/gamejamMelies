using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] Animator textAnim;

    bool isInRange;

    private SpriteRenderer spriteRenderer;

    public bool isDown;
    bool canPlayAnim = false;

    conectedLever connectedlever;
    private void Start()
    {
        connectedlever = GetComponent<conectedLever>();

        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {

        if (Input.GetButtonDown("Use"))
        {
            if (isDown && canPlayAnim && isInRange)
            {
                anim.Play("UpElevator");
                StartCoroutine(DelayAnim());
                isDown = true;
                spriteRenderer.flipX = true;
            }

            if (!isDown && canPlayAnim && isInRange)
            {
                anim.Play("DownElevator");
                StartCoroutine(DelayAnim());
                isDown = false;
                spriteRenderer.flipX = false;
            }
            if (connectedlever != null) {
                connectedlever.updateLever();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            textAnim.SetBool("On", true);
            canPlayAnim = true;
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            textAnim.SetBool("On", false);
            canPlayAnim = false;
            isInRange = false;
        }
    }
    public void flick() {
        isDown = !isDown;
        spriteRenderer.flipX = spriteRenderer.flipX;
    }
    IEnumerator DelayAnim()
    {
        canPlayAnim = false;
        yield return new WaitForSeconds(1.5f * Time.deltaTime);
        canPlayAnim = true;
    }


}
