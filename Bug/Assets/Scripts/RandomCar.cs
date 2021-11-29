using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCar : MonoBehaviour
{
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float moveInput = 0f;
    [SerializeField] float maxNumberOfHits = 3f;
    float hits = 0;
    private GameManager gameManager;
  

    private void Awake() {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void  Start() {
        moveInput = Random.Range(0f,0.5f);
        
    }
    private void Update() {
        
        float moveAmount = moveInput * moveSpeed * Time.deltaTime;
        transform.Translate(0,moveAmount,0);

        if(hits == maxNumberOfHits && gameObject.tag == "RandomCar"){
            gameManager.RemoveLife();
            gameManager.AudioPlayExplosion();
            Destroy(gameObject);
        }
        if(hits == maxNumberOfHits && gameObject.tag == "Bug"){
            gameManager.AddToScore(100);
            gameManager.AudioPlayExplosion();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Boundary"){
            Destroy(gameObject);
        }
        if(other.gameObject.tag == "Driver"){
            gameManager.AudioPlayCrash();
            hits++;
        }
    }
}
