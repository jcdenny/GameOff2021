using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCreator : MonoBehaviour {

    [SerializeField] float maxTime = 5f;
    [SerializeField] GameObject randomCarPrefab;
    [SerializeField] GameObject bugPrefab;
    [SerializeField] GameObject driver;
    [SerializeField] float yOffset;
    private float countDown;
    private float bugChance;
    private GameObject carPrefab;
    
    
    void Start()
    {
        countDown = randomSpawnMax(maxTime); 
    }

    // Update is called once per frame
    void Update(){
        transform.position = driver.transform.position + new Vector3(0,yOffset,0);
        countDown -= Time.deltaTime;
        if(countDown <= 0){
            carSpawner();
            countDown = randomSpawnMax(maxTime); 
        }
        
    }

    private void carSpawner( ){
        bugChance = Random.Range(0f,10f);
        if(bugChance > 5f){
            carPrefab = bugPrefab; 
        }
        else{
            carPrefab = randomCarPrefab;
        }
        Instantiate(carPrefab, transform.position, Quaternion.identity);
    }
    private float randomSpawnMax(float maxSpawnTime){
        return Random.Range(0f,maxSpawnTime);
    }

}
