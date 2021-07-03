using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ResetObstacles : MonoBehaviour
{
    bool isInrange;
    [SerializeField] Animator anim1;
    [SerializeField] Animator anim2;

    [SerializeField] RotateScenario2 rot1;
    [SerializeField] RotateScenario2 rot2;
    private void Update()
    {
        if (Input.GetButtonDown("Use") && isInrange)
        {
            anim1.SetTrigger("reset");
            anim2.SetTrigger("reset");
            rot1.reset();
            rot2.reset();
        }
    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInrange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInrange = false;
    }
}
