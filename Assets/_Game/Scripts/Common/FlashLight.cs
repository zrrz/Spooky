using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject flashlight;
    public GameObject sound;

    void Start()
    {
        
    }
    void playsound()
    {
        sound.GetComponent<AudioSource>().Play();
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
