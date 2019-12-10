using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;
    private void OnMouseDown() {
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach(DefenderButton button in buttons) {
            button.GetComponent<SpriteRenderer>().color = new Color32(41,41,41,255);
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        var Spawner = FindObjectOfType<DefenderSpawner>();
        Spawner.setSelectedDefender(defenderPrefab);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
