using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    [SerializeField] GameObject driver;
    [SerializeField] GameObject roadPrefab;
    private void Update() {
        transform.position = driver.transform.position + new Vector3(0,-20,0);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        Instantiate(roadPrefab, new Vector3(0,driver.transform.position.y+10,0), Quaternion.identity);
        Destroy(other.gameObject);
    }
}
