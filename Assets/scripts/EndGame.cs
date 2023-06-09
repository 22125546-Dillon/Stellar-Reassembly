using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public int totalParts;
    private ItemCollectorL2 itemCollectorL2;
    public int Parts1;
    public int Parts2;

    private AudioSource finishSound;
    private void Start()
    {
        itemCollectorL2 = FindObjectOfType<ItemCollectorL2>();
        finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            finishSound.Play();

            PlayerPrefs.SetInt("collected2", itemCollectorL2.parts);
            Parts1 = PlayerPrefs.GetInt("collected");
            Parts2 = PlayerPrefs.GetInt("collected2");
            totalParts = Parts1 + Parts2;

            Debug.Log("Total Parts Collected: " + totalParts);

            if (totalParts < 15)
            {
                Invoke("LoadNextScene", 2f); // Invoke the LoadNextScene method after a 2-second delay
            }
            else
            {
                Invoke("LoadAnotherScene", 2f); // Invoke the LoadAnotherScene method after a 2-second delay
            }
        }
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene("Game Over Screen"); // Load the "NextScene"
    }

    private void LoadAnotherScene()
    {
        SceneManager.LoadScene("Winning Screen"); // Load the "AnotherScene"
    }
}
