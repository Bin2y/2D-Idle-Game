using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    //간단하게 리지드바디를 이용해서 움직임 구현
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Move(Vector2 value)
    {
        rb.velocity = value;
    }

}
