using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachPlayer : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] float radius;

    Transform player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void Update()
    {
        bool isInRange = Physics2D.OverlapCircle(target.position, radius, 7);
        if (isInRange)
        {
            player.SetParent(transform);
        }
        else
        {
            player.SetParent(null);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(target.position, radius);
    }

}
