using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PeterScript : MonoBehaviour
{
    public float speed = 3.0f;
    public Text score;
    public Text gem;
    public Text health;
    private int healthValue = 5;
    private int scoreValue = 0;
    public int gemValue= 0;
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    public bool poweredUp;
    public bool reset;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        score.text = scoreValue.ToString();
        gem.text = gemValue.ToString();
        health.text = healthValue.ToString();
        poweredUp = false;
        reset = false;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Gem")
        {
            scoreValue += 100;
            score.text = scoreValue.ToString();
            gemValue += 1;
            gem.text = gemValue.ToString();
            Destroy(collision.collider.gameObject);
        }
        if (collision.collider.tag == "Enemy" && poweredUp == false)
        {
            healthValue -= 1;
            health.text = healthValue.ToString();
            transform.position = new Vector2(33.1f, 31.06f);
            reset = true;
        }
        if (collision.collider.tag == "Enemy" && poweredUp == true)
        {
            scoreValue += 500;
        }
        if (collision.collider.tag == "Shield")
        {
            Destroy(collision.collider.gameObject);
            poweredUp = true;
        }
    }
    // Update is called once per frame

    void Update()
    {
        if (gemValue == 83)
        {
            transform.position = new Vector2(321.3f, 31.06f);
        }

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }
}
