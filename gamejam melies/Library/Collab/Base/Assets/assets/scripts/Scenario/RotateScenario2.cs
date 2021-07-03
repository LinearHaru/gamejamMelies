using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScenario2 : MonoBehaviour
{
    public float soundSmooth = 10;

    //[SerializeField] GameObject scenario;
    public bool canInteract = false;

    AudioSource source;
    public float volume = 4;

    public Animator anim;
    public int rotation = 3;

    int counter = 0;
    bool onDelay = true;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Use") && canInteract && onDelay)
        {
            rotation += 1;
            anim.SetFloat("rotation", rotation);
            if (rotation >= 4)
                rotation = 0;
            StartCoroutine(nameof(delay));
            onDelay = false;
            counter = 0;
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
    IEnumerator delay() {
        while (true) {

            if (counter == 1)
            {
                onDelay = true;
                StopAllCoroutines();
            }
            counter += 1;
            yield return new WaitForSeconds(2f);
        }
    }
}
