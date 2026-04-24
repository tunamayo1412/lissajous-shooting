using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ClearScript : MonoBehaviour
{
    bool cleared;
    float delta = 0;
    float span = 1;
    [SerializeField] GameObject clear_text;
    AudioSource crash;
    CinemachineImpulseSource impulse;

    // Start is called before the first frame update
    void Start()
    {
        cleared = false;
        clear_text.SetActive(false);
        crash = GetComponent<AudioSource>();
        impulse = GetComponent<CinemachineImpulseSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cleared)
        {
            delta += Time.deltaTime;
            if(delta >= span)
            {
                clear_text.SetActive(true);
                crash.Play();
                impulse.GenerateImpulse();
                cleared = false;
                delta = 0;
            }
        }

    }

    public void Clear()
    {
        cleared = true;
        delta = 0;
        crash.Play();
        impulse.GenerateImpulse();
    }
}
