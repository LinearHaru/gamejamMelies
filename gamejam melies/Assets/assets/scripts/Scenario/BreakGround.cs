using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakGround : MonoBehaviour
{
    SfxManager SFXManager;
    [SerializeField] private float valueToBreak;
    Animator anim;

    public float delay;
    void Start()
    {
        SFXManager = GameObject.FindGameObjectWithTag("SFXManager").GetComponent<SfxManager>();

        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //if (playerVelocity >= valueToBreak)
            if (collision.relativeVelocity.y <= valueToBreak)
            {
                SFXManager.PlaySfx(1);
                anim.SetTrigger("Break");
                Destroy(gameObject);
            }
        }
    }

   
}
