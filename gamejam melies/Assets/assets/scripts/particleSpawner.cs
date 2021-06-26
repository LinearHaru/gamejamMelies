using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleSpawner : MonoBehaviour
{
    private playerMovement player;
    [SerializeField] Transform position;
    [SerializeField] GameObject prefab;
    void Start()
    {
        player = GetComponent<playerMovement>();
    }

    private void FixedUpdate()
    {
        if (player.onGround && !player.wasOnGround)
        {
            GameObject particle = Instantiate(prefab);
            particle.transform.position = position.position;
        }
    }
}
