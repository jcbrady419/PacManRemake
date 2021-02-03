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
    private int gemValue= 0;
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        score.text = scoreValue.ToString();
        gem.text = gemValue.ToString();
        health.text = healthValue.ToString();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Gem")
        {
            scoreValue += 100;
            score.text = scoreValue.ToString();
            gemValue += 1;
            gem.text = gemValue.ToString();
            Destroy(collision.collider.gameObject);
        }
        if (collision.collider.tag == "Enemy")
        {
            healthValue -= 1;
            health.text = healthValue.ToString();
            transform.position = new Vector2(-0.43f, -0.46f);
        }
    }
    // Update is called once per frame
    void Update()
    {
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
