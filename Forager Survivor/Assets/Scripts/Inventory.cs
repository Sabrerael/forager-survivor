using UnityEngine;

public class Inventory : MonoBehaviour {
    private int scrapCollected;

    public void AddScrap() {
        scrapCollected++;
        Debug.Log(scrapCollected);
    }
}
