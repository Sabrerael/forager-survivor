using UnityEngine;

public class Inventory : MonoBehaviour {
    private int scrapCollected;

    public void AddScrap() {
        scrapCollected++;
        Debug.Log(scrapCollected);
    }

    public int GetScrap() {
        return scrapCollected;
    }

    public void UseScrap(int value) {
        scrapCollected -= value;
        Debug.Log(scrapCollected);
    }
}
