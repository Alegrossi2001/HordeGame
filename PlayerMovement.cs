using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class PlayerMovement : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float speed = 5f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private FixedJoystick joystick;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();   
    }

    void CalculateMovement()
    {
        #region WASD_MOVEMENT
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * Time.deltaTime * speed);
        #endregion

        //Joystick movement
        rb.velocity = new Vector2(joystick.Horizontal *speed,  joystick.Vertical * speed);

    }
}
