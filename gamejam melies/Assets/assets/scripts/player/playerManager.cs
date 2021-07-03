using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{

    private GameObject player;
    private Animator anim;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = player.GetComponent<Animator>();
    }

    public void disablePlayerMovement() {

        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        player.GetComponent<playerMovement>().enabled = false;
        player.GetComponent<lightManager>().enabled = false;
        player.GetComponent<playerSound>().enabled = false;
        player.GetComponent<particleSpawner>().enabled = false;

        anim.SetFloat("velocityX", 0);
        anim.SetFloat("velocityY", 0);
        anim.SetBool("ground", true);
        anim.SetBool("crouching", false);
    }
    public void enablePlayerMovement()
    {
        player.GetComponent<playerMovement>().enabled = true;
        player.GetComponent<playerMovement>().onGround=true;
        player.GetComponent<playerMovement>().wasOnGround=true;
        player.GetComponent<lightManager>().enabled = true;
        player.GetComponent<playerSound>().enabled = true;
        player.GetComponent<particleSpawner>().enabled = true;
    }
}
