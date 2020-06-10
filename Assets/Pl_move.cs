using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Pl_move : MonoBehaviour
{


    Player_off player_Off;
    public AudioManager audio_player;
    public float jump_h = 1f;
    public float max_h = 14f;
    private Rigidbody2D rb2D;
    public Vector2 v = Vector2.zero;
    public float direction=1;
    Vector3 lastVelocity;
    public bool grounded = false;
    public Vector3 colliderOffset;
    public LayerMask groundLayer;
    public float gravity = 2;
    public float fallMultiplayer = 4f;

    public float GroundLength = 0.5f;

    bool facingRight = true;
    bool long_fall = false;
    
    [SerializeField]
    Animator anim;
    public int score;
  
    void Start()
    {   
    
        player_Off =transform.GetComponent<Player_off>();
        Application.targetFrameRate = 60;
        rb2D = transform.GetComponent<Rigidbody2D>();
        audio_player = FindObjectOfType<AudioManager>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
      
        lastVelocity = rb2D.velocity;
        grounded = Physics2D.Raycast(transform.position + colliderOffset, Vector2.down, GroundLength, groundLayer) ||
            Physics2D.Raycast(transform.position - colliderOffset, Vector2.down, GroundLength, groundLayer);
  
        if ((direction > 0 && !facingRight) || (direction < 0 && facingRight))
        { Flip(); }

        if (!grounded)
        {
            anim.SetBool("jump", true);
            if (rb2D.velocity.y < 0)
            {
                rb2D.gravityScale = gravity * fallMultiplayer;
                anim.SetBool("Usual_fall", true);
            }
            if (rb2D.velocity.y < -10f)
            {
                anim.SetBool("fall", true);
                long_fall = true;
            }
        }
        else if (grounded)
        {
            rb2D.gravityScale = gravity;
            anim.SetBool("jump", false);
            anim.SetBool("Usual_fall", false);
            if (long_fall)
            {
               audio_player.Play("Fall");
                long_fall = false;
                player_Off.enabled = true;
            }
        }

        if (Input.touchCount > 0)
        {
            anim.SetBool("fall", false);
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            if (touchPos.x > 0)
                direction = 1;
            else if (touchPos.x < 0)
                direction = -1;
            else direction = 0;
            if (grounded && touch.phase == TouchPhase.Stationary && jump_h < max_h)
            {
                jump_h += 10f * Time.deltaTime;
            }
            else if (grounded && (touch.phase == TouchPhase.Ended || jump_h > max_h))
            {
                Jump();
            }
        }

    }

    void Jump()
        {
            audio_player.Play("Jump");
            v.x = direction * jump_h/2;
            v.y = jump_h;
            rb2D.AddForce(v, ForceMode2D.Impulse);
            lastVelocity = rb2D.velocity;
            jump_h = 1f;
        }
  
        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.tag == "wall")
            {
                Vector3 contactPoint = col.contacts[0].point;
                Vector3 center = col.collider.bounds.max;
                if (contactPoint.y < center.y*2)
                {
                audio_player.Play("Collide");
                    var speed = lastVelocity.magnitude;
                    var Reflect_Dir = Vector3.Reflect(lastVelocity.normalized / 1.5f, col.contacts[0].normal);
                    rb2D.velocity = Reflect_Dir * Mathf.Max(speed);
                }

            }
          
            

        }

        void Flip()
        {
            facingRight = !facingRight;
            transform.rotation = Quaternion.Euler(0, facingRight ? 0 : 180, 0);
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position + colliderOffset,
                transform.position + colliderOffset + Vector3.down * GroundLength);

            Gizmos.DrawLine(transform.position - colliderOffset,
                transform.position - colliderOffset + Vector3.down * GroundLength);
        }
    } 
