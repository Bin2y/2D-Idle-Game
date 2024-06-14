using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public void Move(Vector2 value)
    {
        Debug.Log(value);
        transform.position += (Vector3)value;
    }
}
