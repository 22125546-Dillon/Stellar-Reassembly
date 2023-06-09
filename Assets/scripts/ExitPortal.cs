using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPortal : MonoBehaviour
{
    private AudioSource ExitSound;
    private bool hasPlayedSound = false;

    private void Start()
    {
        ExitSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !hasPlayedSound)
        {
            ExitSound.Play();
            hasPlayedSound = true;
        }
    }
}
