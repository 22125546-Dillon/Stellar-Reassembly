using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollectorL2 : MonoBehaviour
{
    public int parts = 0;

    [SerializeField] private Text PartsText;

    private void Start()
    {



        PartsText.text = "Parts Collected: " + parts;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Parts"))
        {
            Destroy(collision.gameObject);
            parts++;
            PartsText.text = "Parts Collected: " + parts;

            // Store the updated number of parts collected in PlayerPrefs



        }

    }

}
