using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour
{

    public float speed = 4;
    public float jumpforce = 10;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    [HideInInspector]
    public bool lookingRight = true;

    private Rigidbody2D rdbd;
    //private Animator anim;
    public bool crouching = false;
    public bool onGround = true;
    public bool wasOnGround = true;

    // Use this for initialization
    void Start()
    {
        rdbd = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (v < -.05)
            crouching = true;
        else
            crouching = false;

        if ((v > 0 || Input.GetButton("Jump")) && onGround)
            rdbd.velocity = new Vector2(rdbd.velocity.x,jumpforce * Time.fixedDeltaTime);


        rdbd.velocity = new Vector2(h * speed * Time.fixedDeltaTime, rdbd.velocity.y);
        wasOnGround = onGround;
        onGround = Physics2D.OverlapCircle(groundCheck.position, 0.15f, whatIsGround);

        if ((h > 0 && !lookingRight) || (h < 0 && lookingRight))
            Flip();

        //anim.SetFloat("velocityX", Mathf.Abs(h));
        //anim.SetFloat("velocityY", rdbd.velocity.y);
        //anim.SetBool("ground", onGround);
        //anim.SetBool("crouching", crouching);

    }

    public void Flip()
    {
        lookingRight = !lookingRight;
        Vector3 myScale = transform.localScale;
        myScale.x *= -1;
        transform.localScale = myScale;
    }
}