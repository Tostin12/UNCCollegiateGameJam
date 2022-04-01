using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb2d;

    public BoxCollider2D Collider;
    public float speedf=1;
    public float jumpf;

    public Vector2 CrouchingSize;
    public Vector2 StandingSize;

    private bool jump;
    private void Start()
    {
        rb2d=gameObject.GetComponent<Rigidbody2D>();

        Collider=GetComponent<BoxCollider2D>();

        Collider.size=StandingSize;

        StandingSize=Collider.size;

        jump=false;

        
    }

    // Update is called once per frame
    private void Update()
    {
       var movement= Input.GetAxis("Horizontal");
       transform.position+=new Vector3(movement,0,0)*Time.deltaTime*speedf;

       if(!Mathf.Approximately(0,movement))
       transform.rotation=movement > 0 ? Quaternion.Euler(0,180,0):Quaternion.identity;

       if(Input.GetButtonDown("Jump") && Mathf.Abs(rb2d.velocity.y)<0.001f)
       {
           rb2d.AddForce(new Vector2(0, jumpf),ForceMode2D.Impulse);
           jump=true;
       }

       if(Input.GetButtonDown("Crouch"))
       {
           Collider.size=CrouchingSize;
          
       }

       if(Input.GetButtonUp("Crouch"))
       {
           Collider.size=StandingSize;
           
       }
    }
}
