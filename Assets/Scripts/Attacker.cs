using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{

    // [Range (0f, 5f)][SerializeField] float walkSpeed = 1f;
    float currentSpeed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        Move();
    }

    private void Move () {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
    }

    public void SetMovementSpeed(float speed) {
        currentSpeed = speed;
    }
}
