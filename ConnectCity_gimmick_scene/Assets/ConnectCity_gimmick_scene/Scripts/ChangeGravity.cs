using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class ChangeGravity : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3; //�ړ����x
    [SerializeField] private Vector3 localGravity;
    [SerializeField] private Direction direction;
    float moveX = 0f;
    float moveZ = 0f;

    // Start is called before the first frame update
    void Start()
    {
        localGravity = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        switch(direction)
        {
            case Direction.UP:
                // �d�͂�������ɃZ�b�g
                localGravity = Vector3.up * moveSpeed;
                break;
            case Direction.DOWN:
                // �d�͂��������ɃZ�b�g
                localGravity = Vector3.down * moveSpeed;
                break;
            case Direction.LEFT:
                // �d�͂��������ɃZ�b�g
                localGravity = Vector3.left * moveSpeed;
                break;
            case Direction.RIGHT:
                // �d�͂��E�����ɃZ�b�g
                localGravity = Vector3.right * moveSpeed;
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        localGravity = Vector3.zero;
    }

}

public enum Direction
{
    /// <summary>��</summary>
    UP
    /// <summary>��</summary>
    , DOWN
    /// <summary>��</summary>
    , LEFT
    /// <summary>�E</summary>
    , RIGHT
}
