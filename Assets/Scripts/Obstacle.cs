using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float spinSpeed;
    [SerializeField] private float offset;

    private int spinDirection;

    void Start()
    {
        spinDirection = Random.Range(0, 2) == 0 ? 1 : -1;
        transform.position = new Vector3(transform.position.x + offset * spinDirection, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, -spinDirection * spinSpeed));

        //Destroy after a while out of screen
        if (transform.position.y < Camera.main.ScreenToWorldPoint(Vector3.zero).y - 5)
        {
            Destroy(gameObject);
        }
    }

}
