using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{

    public bool isOnGround = false;
    public RigidBody2D rb;
    public LayerMask groundLayers;
    public bool isRolling = false;
    public float jumpForce = 40f;
    public Transform checkPoint;
    public float checkRadius = 0.2f;
 
    
}
