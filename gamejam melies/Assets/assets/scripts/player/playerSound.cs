using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSound : MonoBehaviour
{
    private playerMovement player;
    private AudioSource source;

    [Header("jump")]
    [SerializeField] AudioClip jumpSound;
    [SerializeField] float jumpVolume;

    [Header("fall")]
    [SerializeField] AudioClip[] fallSound;
    [SerializeField] float fallVolume;
    void Start()
    {
        player = GetComponent<playerMovement>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (player.jumpTimer > 0 && !player.onGround && player.wasOnGround)
        {
            source.PlayOneShot(jumpSound, jumpVolume);
        }
        else if (player.onGround && !player.wasOnGround)
        {
            source.PlayOneShot(fallSound[Random.RandomRange(0, fallSound.Length)], fallVolume);
        }
    }
}
