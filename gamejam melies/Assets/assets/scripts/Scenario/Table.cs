
using UnityEngine.Experimental.Rendering.Universal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField] Animator textAnim;

    [SerializeField] Animator lightAnim;
    playerManager player;

    public Dialogue dialog;
    public DialogueManager dialogManager;

    bool canPlayAnim = false;
    bool onDialog = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerManager>();
    }
    private void Update()
    {

        if (Input.GetButtonDown("Use"))
        {
            if (!onDialog && canPlayAnim)
            {
                textAnim.SetBool("On", false);
                onDialog = true;
                player.disablePlayerMovement();
                dialogManager.StartDialogue(dialog);
            }
            else if (onDialog)
            {
                if (dialogManager.NextSentence())
                {
                    lightAnim.SetBool("On", true);
                    textAnim.SetBool("On", true);
                    player.enablePlayerMovement();
                    onDialog = false;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            textAnim.SetBool("On", true);
            canPlayAnim = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            textAnim.SetBool("On", false);
            canPlayAnim = false;
        }
    }


}
