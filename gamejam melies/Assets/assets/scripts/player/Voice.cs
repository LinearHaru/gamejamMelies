using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voice : MonoBehaviour
{
    public List<GameObject> breakables = new List<GameObject>();

    public static bool canVoice = false;

    public float delay;

    public Animator lightAnim;

    private void Update()
    {
        if(canVoice && Input.GetButtonDown("Voice"))
        {
            lightAnim.SetTrigger("Shout");
            StartCoroutine(VoicePower());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("VoiceGround"))
        {
            breakables.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("VoiceGround"))
        {
            breakables.Remove(collision.gameObject);
        }
    }

    IEnumerator VoicePower()
    {

      
        if (breakables.Count > 0)
        {
            foreach (GameObject obj in breakables)
            {
                obj.GetComponent<Animator>().SetTrigger("Break");

                yield return new WaitForSeconds(delay);
            }
        }
    }
}
