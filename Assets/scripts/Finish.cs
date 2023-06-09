using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private ItemCollector itemCollector;
    private AudioSource finishSound;
    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
        itemCollector = FindObjectOfType<ItemCollector>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player") 
        {
            finishSound.Play();
            Invoke("CompleteLevel", 3.5f);
            
        }
    }
    private void CompleteLevel()
    {
        PlayerPrefs.SetInt("collected", itemCollector.parts);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
