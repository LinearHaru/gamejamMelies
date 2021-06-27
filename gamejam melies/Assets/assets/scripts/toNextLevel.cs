using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toNextLevel : MonoBehaviour
{
    [SerializeField] private int levelToChange; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        levelChanger.instance.ChangeLevel(levelToChange);
    }
}
