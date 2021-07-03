using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScenario : MonoBehaviour
{
    public float delay = .01f;
    public float smooth = 10;
    public Vector3 angToRotate;
    [SerializeField] GameObject scenario;

    [SerializeField] Animator anim;
    public bool canInteract = false;

    SpriteRenderer spriteRenderer;
    private void Start()
    {
        angToRotate = transform.eulerAngles;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Use") && canInteract)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
            Debug.Log(angToRotate.z);
            angToRotate =new Vector3(angToRotate.x, angToRotate.y, angToRotate.z - 90);
            StartCoroutine(nameof(rotate));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            canInteract = true;
            anim.SetBool("On", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canInteract = false;
        }
    }

    IEnumerator rotate()
    {
        while(Mathf.Abs(scenario.transform.rotation.z - angToRotate.z)>1)
        {
            Quaternion angle = Quaternion.Euler(angToRotate);
            scenario.transform.rotation = Quaternion.Slerp(scenario.transform.rotation, angle, Time.deltaTime * smooth);

            yield return null;
        }

        scenario.transform.eulerAngles = angToRotate;
        StopAllCoroutines();

        Debug.Log("c");
    }
}
