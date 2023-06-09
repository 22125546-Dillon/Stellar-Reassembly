using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayControls : MonoBehaviour
{
    // Start is called before the first frame update
    public void Rules()
    {
        SceneManager.LoadScene("Game Controls Screen");
    }
}
