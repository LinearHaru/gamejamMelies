using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cristal : MonoBehaviour
{
    public Dialogue dialog;
    public DialogueManager dialogManager;
    playerManager player;
    [SerializeField] Animator textAnim;

    bool isInRange;
    bool onDialog = false;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
            textAnim.SetBool("On", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            textAnim.SetBool("On", false);
        }
    }

    private void Update()
    {
        if(isInRange && Input.GetButtonDown("Use"))
        {

            if (!onDialog && isInRange)
            {
                onDialog = true;
                player.disablePlayerMovement();
                dialogManager.StartDialogue(dialog);
                textAnim.SetBool("On", false);
            }
            else if (onDialog)
            {
                if (dialogManager.NextSentence())
                {
                    Voice.canVoice = true;
                    player.enablePlayerMovement();
                    onDialog = false;
                    textAnim.SetBool("On", true);
                }
            }
        }
    }


}
