using TMPro;
using UnityEngine;

// TODO Turn this into an Enum and Library/Map
public class Inventory : MonoBehaviour {
    [SerializeField] TextMeshProUGUI debugText;

    private int scrapCollected;
    private int upgradePartsCollected;

    public void AddScrap() {
        scrapCollected++;
        UpdateText();
    }

    public int GetScrap() {
        return scrapCollected;
    } 

    public void UseScrap(int value) {
        scrapCollected -= value;
        UpdateText();
    }

    public void AddUpgradePart() {
        upgradePartsCollected++;
        UpdateText();
    }

    public int GetUpgradeParts() {
        return upgradePartsCollected;
    }

    public void UseUpgradeParts(int value) {
        upgradePartsCollected -= value;
        UpdateText();
    }

    private void UpdateText() {
        debugText.text = "Scrap: " + scrapCollected + "\nUpgrade Parts: " + upgradePartsCollected;
    }
}
