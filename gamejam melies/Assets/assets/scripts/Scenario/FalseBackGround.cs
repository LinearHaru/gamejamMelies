using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalseBackGround : MonoBehaviour
{
    [SerializeField]private GameObject elevator;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetTrigger("FadeIn");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetTrigger("FadeOut");
        }
    }
}
