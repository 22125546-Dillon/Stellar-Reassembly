using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public GameObject Lives1;
    public GameObject Lives2;
    public GameObject Lives3;  
    public GameObject Lives4;
    private Rigidbody2D rb;
    private Animator anim;
    private int trapCollisionCount = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //Lives1 = GameObject.Find("Lives1");
        //Lives2 = GameObject.Find("Lives2");
        Lives3 = GameObject.Find("Lives3");
        Lives4 = GameObject.Find("Lives4");
        //Lives3.SetActive(true);
        //Lives4.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            trapCollisionCount++;


            if (trapCollisionCount == 1)
            {
                //Lives1.SetActive(false);
                Lives3.SetActive(false);

            }
            else if (trapCollisionCount == 2)
            {
                //Lives2.SetActive(false);
                Lives4.SetActive(false);
                Die();
            }


        }
        else if (collision.gameObject.CompareTag("InstantDeath"))
        {
            Lives1.SetActive(false);
            Lives2.SetActive(false);
            Die();
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
