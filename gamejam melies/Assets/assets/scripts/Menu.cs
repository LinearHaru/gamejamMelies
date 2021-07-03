using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    private playerManager player;
    public Animator blurAnim;
    public GameObject text;
    public GameObject logo;
    BgMusicScript BGMusic;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerManager>();
        player.disablePlayerMovement();
        BGMusic = GameObject.FindGameObjectWithTag("BGMusic").GetComponent<BgMusicScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            BGMusic.ChangeAudioSnapshot();
            blurAnim.SetTrigger("Blur");
            player.enablePlayerMovement();
            text.SetActive(false);
            logo.SetActive(false);
            this.enabled = false;
        }
    }
}
