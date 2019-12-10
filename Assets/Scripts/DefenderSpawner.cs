using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    private void OnMouseDown() {
        SpawnDefender(GetSquareClicked());
    }

    private Vector2 GetSquareClicked() {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 snappedPos = SnapToGrid(worldPos);
        return snappedPos;
    }

    public void setSelectedDefender (Defender defenderToSelect) {
        defender = defenderToSelect;
    }

    private void SpawnDefender (Vector2 position) {
        Defender newDefender = Instantiate(defender, position, transform.rotation) as Defender;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos) {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }
}
