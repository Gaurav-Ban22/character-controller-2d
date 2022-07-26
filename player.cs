using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    public playerControl pC;
    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    public bool roll = false;

    // Start is called before the first frame update
    void Start()
    {
        pC = GetComponent<playerControl>();
        
    }

    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetButtonDown("Jump")) {
            jump = true;
        }
        if (Input.GetKeyUp(KeyCode.Q)) {
            roll = true;
        }
    
        
    }

    void FixedUpdate() {
        pC.perform(horizontalMove * Time.fixedDeltaTime, roll, jump);
        jump = false;
        roll = false;
    }
}
