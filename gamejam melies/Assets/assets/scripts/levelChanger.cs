using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelChanger : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private int levelToChange;

    public static levelChanger instance;

    private void Awake()
    {
        instance = this;
    }
    public void ChangeLevel(int levelIndex)
    {
        levelToChange = levelIndex;
        anim.SetTrigger("FadeOut");
        StartCoroutine(OnFadeComplete());
    }

   IEnumerator OnFadeComplete()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(levelToChange);
    }
}
