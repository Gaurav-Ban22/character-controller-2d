using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{

    public bool isOnGround = false;
    public Rigidbody2D rb;
    public LayerMask groundLayers;
    public bool isRolling = false;
    public float jumpForce = 600f;
    public Transform checkPoint;
    public float checkRadius = 0.2f;
    public BoxCollider2D rollCol;
    public float airControlMod = 5f;
    public CapsuleCollider2D normalCol;
    public bool facingRight;

    private Vector3 vel = Vector3.zero;
    public bool airControl = true;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    public void perform(float move, bool roll, bool jump) {
        if (isOnGround) {
            //THX BRACKEYS QALSO UNTIYJEFNUJRCVAERJTABSKBNGERFJBEURG RGJ ERTGJNSDFVUI FCVKsdH
            // Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector2(move * 10f, rb.velocity.y);
			// And then smoothing it out and applying it to the character
			rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref vel, 0.05f);

            if (move > 0 && !facingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (move < 0 && facingRight)
			{
				// ... flip the player.
				Flip();
			}
            //thx brackeys :)
        }
        else if (!isOnGround && airControl) {

            Vector3 targetVelocity = new Vector2(move * airControlMod, rb.velocity.y);
			// And then smoothing it out and applying it to the character
			rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref vel, 0.05f);

            if (move > 0 && !facingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (move < 0 && facingRight)
			{
				// ... flip the player.
				Flip();
			}
            //thx brackeys :)

            

        }
        if (isOnGround && jump) {

            isOnGround = false;
            rb.AddForce(new Vector2(0f, jumpForce));

        } 

        if (roll) {
            Vector3 targetVelocity = new Vector2(move * 20f, rb.velocity.y);
			// And then smoothing it out and applying it to the character
			rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref vel, 0.05f);
        }

        



    }



    void FixedUpdate() {
        isOnGround = false;
        //thx brackeys :) unity engine
        Collider2D[] colliders = Physics2D.OverlapCircleAll(checkPoint.position, checkRadius, groundLayers);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
			    isOnGround = true;
                Debug.Log("n ground");
			
			}
           
		}
    }

    private void Flip()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
    //brackeys is cool
 
    
}