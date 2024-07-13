using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeBuilding : Building {
    private Gun playerGun;

    private void Start() {
        playerGun = FindObjectOfType<Gun>();
    }

    protected override void BuildItems() {
        timer += Time.deltaTime;
        if (timer >= buildTime) {
            playerGun.UpgradeGun();
            builtItems++;
            timer = 0;
            if (builtItems == itemsToBuild) {
                builtItems = 0;
                itemsToBuild = 0;
                Debug.Log("Done Building");
            }
        }  
    }
}
