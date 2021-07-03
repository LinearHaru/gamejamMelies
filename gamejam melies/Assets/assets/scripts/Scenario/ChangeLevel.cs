using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private int sceneToChange;
    [SerializeField] private GameObject FadeImage;
    private void Start()
    {
        
        FadeImage.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("FadeOut");
            StartCoroutine(OnFadeComplete());
        }
    }

    IEnumerator OnFadeComplete()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneToChange);
    }
}
