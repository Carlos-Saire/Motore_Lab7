using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambialedenombre : MonoBehaviour
{
    AudioSource audios;
    private void Awake()
    {
        audios = GetComponent<AudioSource>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

        }
    }
}
