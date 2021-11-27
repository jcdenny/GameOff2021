using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BoxingGlove : MonoBehaviour
{
    SpriteRenderer leftSpriteRenderer;
    Collider2D leftCollider2D;
    GameObject leftGlove;

    SpriteRenderer rightSpriteRenderer;
    Collider2D rightCollider2D;
    GameObject rightGlove;
    bool collideWithRandomCar;
    bool collideWithBug;
    AudioSource audioSource;


    private GameManager gameManager;
    private void Awake() {
        gameManager = FindObjectOfType<GameManager>();
        leftGlove = GameObject.FindGameObjectWithTag("LeftGlove");
        rightGlove = GameObject.FindGameObjectWithTag("RightGlove");
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        
        leftSpriteRenderer = leftGlove.GetComponent<SpriteRenderer>();
        leftCollider2D = leftGlove.GetComponent<Collider2D>();
        rightSpriteRenderer = rightGlove.GetComponent<SpriteRenderer>();
        rightCollider2D = rightGlove.GetComponent<Collider2D>();

    }

    void Update()
    {
        collideWithRandomCar = false;
        collideWithBug = false;
        if(gameManager.GetLives() <= -1){
            SceneManager.LoadScene("GameOver");
        }
        if(Input.GetKeyDown("o")){
            leftSpriteRenderer.enabled = true;
            leftCollider2D.enabled = true;
            audioSource.Play();
        }
        if(Input.GetKeyUp("o")){
            leftSpriteRenderer.enabled = false;
            leftCollider2D.enabled = false;
        }
        if(Input.GetKeyDown("p")){
            rightSpriteRenderer.enabled = true;
            rightCollider2D.enabled = true;
            audioSource.Play();
        }
        if(Input.GetKeyUp("p")){
            rightSpriteRenderer.enabled = false;
            rightCollider2D.enabled = false;
        }
    }

   private void OnTriggerEnter2D(Collider2D other) {
       if(other.tag == "RandomCar"){
            collideWithRandomCar = true;
            Destroy(other.gameObject);
            gameManager.RemoveLife();
       }
       if(other.tag == "Bug"){
            collideWithBug = true;
            Destroy(other.gameObject);
            gameManager.AddToScore(100);
       }
   }
}
