using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeBuilding : MonoBehaviour {
    [SerializeField] float buildTime = 10;

    private float timer = 0;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player") && other.gameObject.GetComponent<PlayerController>()) {
            //other.gameObject.GetComponent<PlayerController>().SetBuildingContext(this);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player") && other.gameObject.GetComponent<PlayerController>()) {
            //other.gameObject.GetComponent<PlayerController>().UnsetBuildingContext();
        }
    }

    public void StartBuilding(int value) {
        Debug.Log("StartBuilding called with " + value);
        
    }

    private void BuildUpgrade() {
        timer += Time.deltaTime;
        if (timer >= buildTime) {
            
        }  
    }
}
