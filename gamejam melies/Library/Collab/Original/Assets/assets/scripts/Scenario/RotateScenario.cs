using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScenario : MonoBehaviour
{
    public float delay = .01f;
    public float smooth = 10;
    public float soundSmooth = 10;
    public Vector3 angToRotate;
    [SerializeField] GameObject scenario;
    public bool canInteract = false;
    AudioSource source;
    public float volume = 4;


    private void Start()
    {
        source = GetComponent<AudioSource>();
        angToRotate = transform.eulerAngles;
    }
    void Update()
    {
        if (Input.GetButtonDown("Use") && canInteract)
        {
            
            Debug.Log(angToRotate.z);
            angToRotate =new Vector3(angToRotate.x, angToRotate.y, angToRotate.z - 90);
            if (angToRotate.z <= -360)
            {
                angToRotate = new Vector3(angToRotate.x, angToRotate.y, 0);
                scenario.transform.eulerAngles = new Vector3(scenario.transform.eulerAngles.x, scenario.transform.eulerAngles.y, scenario.transform.eulerAngles.z+360);

            }
            StartCoroutine(nameof(rotate));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            canInteract = true;
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
        //while(Mathf.Abs(scenario.transform.rotation.z - angToRotate.z)>1)
        while(true)
        {
            Quaternion angle = Quaternion.Euler(angToRotate);
            //Vector3 before = scenario.transform.eulerAngles;
            scenario.transform.rotation = Quaternion.Lerp(scenario.transform.rotation, angle, Time.deltaTime * smooth);
            //source.volume = Mathf.Lerp(source.volume,
                //Vector3.Distance(before, scenario.transform.eulerAngles) * volume+.3f,
                //Time.deltaTime * soundSmooth);

            yield return new WaitForSeconds(.01f);
        }

        //scenario.transform.eulerAngles = angToRotate;

        //if (scenario.transform.eulerAngles.z == 360 || scenario.transform.eulerAngles.z == -360)
            //scenario.transform.eulerAngles = new Vector3(scenario.transform.eulerAngles.x, scenario.transform.eulerAngles.y, 0);
        
       
        StopAllCoroutines();

    }
}
