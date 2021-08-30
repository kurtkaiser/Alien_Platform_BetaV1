using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private int moveSpeed = 7;
    private Vector3 movement;
    private float jumpHeight = 9f;
    public bool onPlatform = true;
    public Sprite[] sprites;
    public Text scoreText;

    public float yForce = 0;

    private int score = 0;

    Rigidbody2D rigidPlayer;

    void Update()
    {
        Jump();

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            GetComponent<SpriteRenderer>().sprite = sprites[0];
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            GetComponent<SpriteRenderer>().sprite = sprites[1];
        }
    }

    void FixedUpdate()
    {
        if (!onPlatform)
        {
            yForce = yForce - 0.025f;

        }
        movement = new Vector3(Input.GetAxis("Horizontal"), yForce, 0f);
        transform.position = transform.position + movement *
            moveSpeed * Time.deltaTime;
    }


    void Jump()
    {

        if (Input.GetButtonDown("Jump") && onPlatform)
        {
            rigidPlayer.AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            

            rigidPlayer.AddForce(new 
                Vector2(jumpHeight, 0f), ForceMode2D.Impulse);
        }
        else if(collision.collider.tag == "Coin")
        {
            Destroy(collision.gameObject);
            score = score + 1;
            scoreText.text = score.ToString();
        }
    }

    private void Awake()
    {
        rigidPlayer = GetComponent<Rigidbody2D>();
    }
}
