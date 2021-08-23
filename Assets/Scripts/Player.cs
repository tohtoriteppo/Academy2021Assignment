using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{

    
    [SerializeField] private float clickForce;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float gravityScale;

    [SerializeField] private AudioClip audioClipSwitch;

    private GameController controller;


    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType<GameController>();
        GetComponent<SpriteRenderer>().color = GameController.RandomColor();
    }

    // Update is called once per frame
    void Update()
    {
        //Player moves
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, clickForce), ForceMode2D.Force);
            GetComponent<AudioSource>().Play();
        }
        //Lose when out of screen
        if (transform.position.y < Camera.main.ScreenToWorldPoint(Vector3.zero).y)
        {
            controller.EndGame();
        }
    }

    private void FixedUpdate()
    {
        //Restrict the max velocity for easier control
        if(GetComponent<Rigidbody2D>().velocity.y > maxSpeed)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, Mathf.Min(GetComponent<Rigidbody2D>().velocity.y, maxSpeed));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Lose if Obstacle of the same color hits
        if (collision.gameObject.tag == "Obstacle")
        {
            if (collision.gameObject.GetComponent<SpriteRenderer>().color != GetComponent<SpriteRenderer>().color)
            {
                controller.EndGame();
            }
        }
        //Change the color of the player when hit by switch
        else if (collision.gameObject.tag == "Switch")
        {
            Color col = GameController.RandomColor();
            while (col == GetComponent<SpriteRenderer>().color)
            {
                col = GameController.RandomColor();
            }
            GetComponent<SpriteRenderer>().color = col;
            Destroy(collision.gameObject);
            GetComponent<AudioSource>().PlayOneShot(audioClipSwitch);

        }
        //Player found a star
        else
        {
            controller.AddStar();
            Destroy(collision.gameObject);
        }
        
    }

    //When the game starts, the gravity is changed from 0 to this
    public void SetGravity()
    {
        GetComponent<Rigidbody2D>().gravityScale = gravityScale;
    }

}
