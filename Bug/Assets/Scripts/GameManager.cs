using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField] float driverLives = 4f;
    [SerializeField] Color32 lostLifeColor = new Color32(75,68,68,255);
    [SerializeField] GameObject scoreObject;
    [SerializeField] AudioSource explosion;
    [SerializeField] AudioSource crash;
    int score;
    
    GameObject life1;
    GameObject life2;
    GameObject life3;
    TextMeshProUGUI scoreText;
  
    void OnDisable(){
        PlayerPrefs.SetInt("score", score);
    }
    void OnEnable(){
        score  =  PlayerPrefs.GetInt("score");
    }
    private void Awake() {
        life1 = GameObject.Find("Life1");
        life2 = GameObject.Find("Life2");
        life3 = GameObject.Find("Life3");
        scoreText = scoreObject.GetComponent<TextMeshProUGUI>();
    }
    public void RemoveLife(){
        driverLives--;
    }

    public float GetLives(){
        return driverLives;
    }

    public void AddToScore(int scoreToAdd){
        score += scoreToAdd;
    }

    public void AudioPlayExplosion(){
        explosion.Play();
    }

    public void AudioPlayCrash(){
        float pitch = Random.Range(0.4f,1f);
        crash.pitch = pitch;
        crash.Play();
        
    }

    private void Update() {

        scoreText.SetText(score.ToString());
        switch(driverLives){
            case 3:
                life1.GetComponent<Image>().color = lostLifeColor;
                break;
            case 2:
                life2.GetComponent<Image>().color = lostLifeColor;
                break;
            case 1:
                life3.GetComponent<Image>().color = lostLifeColor;
                break;
            default:
                break;
         }
    }
}
