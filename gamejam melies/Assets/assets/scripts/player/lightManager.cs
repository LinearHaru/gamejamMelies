using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class lightManager : MonoBehaviour
{
    private playerMovement player;
    [SerializeField] Light2D light;
    private float onIntensity;
    public float smooth = 10;
    void Start()
    {
        player = GetComponent<playerMovement>();
        onIntensity = light.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.onGround)
            light.intensity = Mathf.Lerp(light.intensity, onIntensity, Time.deltaTime * smooth);
        else
            light.intensity = Mathf.Lerp(light.intensity, 0, Time.deltaTime * smooth);

    }
}
