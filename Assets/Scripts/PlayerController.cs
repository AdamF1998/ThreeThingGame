using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float moveSpeed = 75f;
    public float jumpHeight = 3000f;

    private float axis;
    private Rigidbody2D rb2d;
    private Animator anim;
    private AudioSource audio;
    private bool jumping, isGrounded = false;
    private bool left = false;

	// Use this for initialization
	void Start ()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        //jumping = false;

    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {

        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("Died"))
        {
            SceneManager.LoadScene("SampleScene");
            return;
        }

        if (stateInfo.IsName("Dead"))
        {
            return;
        }

        if (rb2d.position.y < -5)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("SampleScene");
        }

        //Movement left/right
        axis = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(axis * moveSpeed, 0);

        if(axis != 0)
        {
            if (!stateInfo.IsName("Jump") && !stateInfo.IsName("Run"))
            {
                anim.Play("Run");
                Debug.Log("Test");
            }
        }
        else
        {
            if (!stateInfo.IsName("Jump") && !stateInfo.IsName("Idle"))
            {
                anim.Play("Idle");
            }
        }

        if((axis > 0 && left) || (axis < 0 && !left))
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.flipX = !left;
            left = !left;
        }

        if (Input.GetButtonDown("Jump") && isGrounded) /*&& isGrounded)*/
        {
            //jumping = true;
            isGrounded = false;
            rb2d.velocity = (new Vector2(0, jumpHeight));
            anim.Play("Jump");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            anim.Play("Idle");
            Debug.Log(isGrounded);
        }

        if(collision.gameObject.tag == "Enemy")
        {
            audio.Play();
            anim.Play("Dead");
        }

        if(collision.gameObject.tag == "Portal")
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.buildIndex + 1);
        }
    }

    /*private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
            Debug.Log(isGrounded);
        }
    }*/
}
