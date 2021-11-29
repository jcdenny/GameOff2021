using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMenuInput : MonoBehaviour
{
    [SerializeField] string nextScene;
    [SerializeField] KeyCode startingKey;
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        } 
        if (Input.GetKey(startingKey))
        {
            SceneManager.LoadScene(nextScene);
        } 
    }
}
