using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeEnemyScript : MonoBehaviour
{
    private int direction = -1;
    private Vector3 movement;
    public Sprite[] sprites;

    void Update()
    {
        movement = new Vector3(2 * direction, 0f, 0f);
        transform.position = transform.position + movement * Time.deltaTime;
        if(transform.position.y < -7)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        direction = direction * -1;
        if(direction == 1)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[1];
        } else
        {
            GetComponent<SpriteRenderer>().sprite = sprites[0];
        }
    }
}
