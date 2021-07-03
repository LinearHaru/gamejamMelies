using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BgMusicScript : MonoBehaviour
{
    [SerializeField] private AudioMixerSnapshot[] audioSnapshots;

    public int currentSnapshot;
    public static BgMusicScript instance;
    private void Awake() 
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this);
        
    }
    private void Start() 
    {
        currentSnapshot = 0;
    }

    public void ChangeAudioSnapshot()

    {
        if (currentSnapshot < 7)
        {
            currentSnapshot++;
            audioSnapshots[currentSnapshot].TransitionTo(3.0f);
        }

    }
}
