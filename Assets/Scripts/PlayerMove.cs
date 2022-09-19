using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float horizontalMove;
    private float verticalMove;
    private Vector3 moveDirection;
    [SerializeField]
    private float speed;
    void Start()
    {
        
    }


    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        moveDirection = new Vector3(horizontalMove, 0f, verticalMove);
        Move();
    }


    void Move()
    {
        transform.position += moveDirection * speed * Time.deltaTime;
    }
}
