using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class player2 : MonoBehaviour
{
    public bool fliped; 
    public float MoveSpeed = 5f;
    public float jumpforce = 6.5f;
    public float MaxHealth, health = 20;
    public bool isgound = false;
    [SerializeField] private Animator Animatior;

    [SerializeField]
    private Health healthBarUI;

    private Rigidbody2D rb;
    private float horizontalInput;
    public Collider2D myObject;


    public InputAction jump;
    public InputAction left;
    public InputAction right;
    public InputAction Punch;
    public InputAction Kick;


    private void OnEnable()
    {
        jump.Enable();
        left.Enable();
        right.Enable();
        Punch.Enable();
    }

    private void OnDisable()
    {
        jump.Disable();
        left.Disable();
        right.Disable();
        Punch.Disable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        healthBarUI.SetMaxHealt(MaxHealth);
    }

    void Update()
    {
        horizontalInput = 0f;

        if (left.IsPressed())
        {
            horizontalInput = -1f;
            Animatior.SetBool("walking", true);
        }
        else
        {
            Animatior.SetBool("walking", false);
        }

        if (right.IsPressed())
        {
            horizontalInput = 1f;
            Animatior.SetBool("walk back", true);
        }
        else
        {
            Animatior.SetBool("walk back", false);
        }

        rb.linearVelocity = new Vector2(horizontalInput * MoveSpeed, rb.linearVelocity.y);
        this.transform.rotation = Quaternion.Euler(new Vector3(0f, fliped ? 180f : 0f, 0f));

        if (jump.IsPressed() && isgound)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpforce);
            Animatior.SetBool("jump", true);
        }
        else
        {
            Animatior.SetBool("jump", false);
        }

        if (Punch.IsPressed())
        {
            Animatior.SetBool("Punch", true);
            myObject.GetComponent<CircleCollider2D>().enabled = true;
        }
        else
        {
            Animatior.SetBool("Punch", false);
            myObject.GetComponent<CircleCollider2D>().enabled = false;
        }



        if (health == 0)
        {
            Debug.Log("scorpion won");
            SceneManager.LoadScene("scorpo won");
            Animatior.SetBool("dead", true);
        }
        else 
        {
            Animatior.SetBool("dead", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
            isgound = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
            isgound = false;
    }

    public void SetHealth(float healthChange)
    {
        health += healthChange;
        health = Mathf.Clamp(health, 0, MaxHealth);

        healthBarUI.SetHealth(health);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "punch")
            SetHealth(-1);
    }
}
