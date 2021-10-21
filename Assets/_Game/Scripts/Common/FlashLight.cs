using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject flashlight;
    public AudioClip sound;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if(audioSource == null)
        {
            Debug.LogError($"No {typeof(UnityEngine.AudioSource).Name} on gameObject", this);
        }


    }
    void playsound()
    {
        audioSource.PlayOneShot(sound, 0.7F);
        if (sound == null)
        {
            Debug.LogError($"No {typeof(UnityEngine.AudioClip).Name} on gameObject", this);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            flashlight.SetActive(!flashlight.activeSelf);
            playsound();
        }
        

    }




}
