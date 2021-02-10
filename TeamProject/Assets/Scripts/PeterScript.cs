using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PeterScript : MonoBehaviour
{
    public AudioSource BackgroundMusic;
    public AudioSource VictoryMusic;
    public AudioSource DefeatMusic;
    public AudioClip gemSound;
    public AudioClip shieldSound;
    public AudioClip killSound;
    public AudioClip deathSound;
    public float speed = 3.0f;
    public Text score;
    public Text gem;
    public Text health;
    public Text winText;
    public Text loseText;
    public int healthValue = 3;
    private int scoreValue = 0;
    public int gemValue = 0;
    Rigidbody2D rigidbody2d;
    public bool poweredUp;
    public bool reset;
    public static int level;
    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);
    private bool facingRight = true;
    AudioSource audioSource;
    public GameObject hurtPrefab;
    float horizontal;
    float vertical;
    // Start is called before the first frame update
    void Start()
    {

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 1"))
        {
            level = 1;
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 2"))
        {
            level = 2;
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Menu"))
        {
            level = 0;
        }
        rigidbody2d = GetComponent<Rigidbody2D>();
        score.text = scoreValue.ToString();
        gem.text = gemValue.ToString();
        health.text = healthValue.ToString();
        poweredUp = false;
        reset = false;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        BackgroundMusic.loop = true;
        winText.text = "";
        loseText.text = "";
        VictoryMusic.enabled = false;
        DefeatMusic.enabled = false;
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (level == 1)
        {
            if (collision.collider.tag == "Gem")
            {
                scoreValue += 100;
                score.text = scoreValue.ToString();
                gemValue += 1;
                gem.text = gemValue.ToString();
                Destroy(collision.collider.gameObject);
                PlaySound(gemSound);
            }
            if (collision.collider.tag == "Enemy" && poweredUp == false)
            {
                healthValue -= 1;
                health.text = healthValue.ToString();
                reset = true;
                transform.position = new Vector2(33.1f, 31.06f);
                PlaySound(deathSound);
                GameObject pickupObject = Instantiate(hurtPrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);

            }
            if (collision.collider.tag == "Enemy" && poweredUp == true)
            {
                scoreValue += 500;
                poweredUp = false;
                Destroy(collision.collider.gameObject);
                reset = true;
                PlaySound(killSound);
                transform.position = new Vector2(33.1f, 31.06f);
            }
            if (collision.collider.tag == "Shield")
            {
                Destroy(collision.collider.gameObject);
                poweredUp = true;
                PlaySound(shieldSound);
            }
        }
        if (level == 2)
        {
            if (collision.collider.tag == "Gem")
            {
                scoreValue += 100;
                score.text = scoreValue.ToString();
                gemValue += 1;
                gem.text = gemValue.ToString();
                Destroy(collision.collider.gameObject);
                PlaySound(gemSound);
            }
            if (collision.collider.tag == "Enemy" && poweredUp == false)
            {
                healthValue -= 1;
                health.text = healthValue.ToString();
                reset = true;
                transform.position = new Vector2(321.1f, 31.06f);
                PlaySound(deathSound);
                GameObject pickupObject = Instantiate(hurtPrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
            }
            if (collision.collider.tag == "Enemy" && poweredUp == true)
            {
                scoreValue += 500;
                poweredUp = false;
                Destroy(collision.collider.gameObject);
                reset = true;
                PlaySound(killSound);
                transform.position = new Vector2(321.1f, 31.06f);
            }
            if (collision.collider.tag == "Shield")
            {
                Destroy(collision.collider.gameObject);
                poweredUp = true;
                PlaySound(shieldSound);
            }
        }
    }
    // Update is called once per frame

    void Update()
    {
        if (healthValue == 0)
        {
            BackgroundMusic.enabled = false;
            speed = 0.0f;
            loseText.text = "Game Over You Lose! Press R to go to the Menu Screen or ESC to quit.";
            DefeatMusic.enabled = true;
            if (Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadScene("Menu");
            }
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
            Debug.Log("QUIT");
        }
        if (level == 1)
        {
            if (gemValue == 86)
            {
                SceneManager.LoadScene("Level 2");
            }
        }
        if (level == 2)
        {
            if (gemValue == 89)
            {
                winText.text = "Congratulations You Win! Press R to go to the Menu Screen or ESC to quit.";
                BackgroundMusic.enabled = false;
                speed = 0.0f;
                VictoryMusic.enabled = true;
                if (Input.GetKey(KeyCode.R))
                {
                    SceneManager.LoadScene("Menu");
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetInteger("State", 1);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetInteger("State", 0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetInteger("State", 1);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetInteger("State", 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetInteger("State", 1);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetInteger("State", 0);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetInteger("State", 1);
                }
        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetInteger("State", 0);
                }

        if (Input.GetKeyDown(KeyCode.D))
        {
            reset = false;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            reset = false;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            reset = false;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            reset = false;
        }
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);
    }
     


void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
