using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 300f;
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float boostSpeed = 30f;

    [SerializeField] Color32 lostLifeColor = new Color32(75,68,68,255);
    // [SerializeField] AudioSource accelerate;
    
    private GameManager gameManager;
  
    private void Awake() {
        gameManager = FindObjectOfType<GameManager>();
    }


    void Update()
    {
        if(gameManager.GetLives() <= 0){
            SceneManager.LoadScene("GameOver");
        }
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        // if(moveAmount > 0){
        //     accelerate.enabled = true;
            
        // }
        // else{
        //     accelerate.enabled = false;
        // }
   
        
        transform.Rotate(0,0,-steerAmount);
        transform.Translate(0,moveAmount,0);
    }



    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "SpeedUp"){
            moveSpeed = boostSpeed;
        }
    }
}
