using UnityEngine;

// TODO Turn this into an Enum and Library/Map
public class Inventory : MonoBehaviour {
    private int scrapCollected;
    private int upgradePartsCollected;

    public void AddScrap() {
        scrapCollected++;
        Debug.Log("Scrap: " + scrapCollected);
    }

    public int GetScrap() {
        return scrapCollected;
    } 

    public void UseScrap(int value) {
        scrapCollected -= value;
        Debug.Log("Scrap: " + scrapCollected);
    }

    public void AddUpgradePart() {
        upgradePartsCollected++;
        Debug.Log("Upgrade Parts: " + upgradePartsCollected);
    }

    public int GetUpgradeParts() {
        return upgradePartsCollected;
    }

    public void UseUpgradeParts(int value) {
        upgradePartsCollected -= value;
        Debug.Log("Upgrade Parts: " + upgradePartsCollected);
    }
}
