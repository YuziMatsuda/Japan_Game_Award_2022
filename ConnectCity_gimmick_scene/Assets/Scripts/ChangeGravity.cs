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
    [SerializeField] private TriggerEvent onTriggerEnter = new TriggerEvent();
    [SerializeField] private TriggerEvent onTriggerStay = new TriggerEvent();
    float moveX = 0f;
    float moveZ = 0f;
    private Rigidbody rBody;

    // Start is called before the first frame update
    void Start()
    {
        rBody = this.GetComponent<Rigidbody>();
        rBody.useGravity = false; //�ŏ���rigidBody�̏d�͂��g��Ȃ�����
        localGravity = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        switch(direction)
        {
            case Direction.UP:
                moveX = Input.GetAxis("Horizontal") * moveSpeed;
                moveZ = Input.GetAxis("Vertical") * moveSpeed;
                break;
        }
    }

    private void FixedUpdate()
    {
        SetLocalGravity(); //�d�͂�AddForce�ł����郁�\�b�h���ĂԁBFixedUpdate���D�܂����B
    }

    private void SetLocalGravity()
    {
        rBody.AddForce(localGravity, ForceMode.Acceleration);
    }

    private void OnTriggerEnter(Collider other)
    {
        onTriggerEnter.Invoke(other);
    }

    /// <summary>
    /// Is Trigger��ON�ő���Collider�Əd�Ȃ��Ă���Ƃ��́A���̃��\�b�h����ɃR�[�������
    /// </summary>
    /// <param name="other"></param>

    private void OnTriggerStay(Collider other)
    {
        //onTriggerStay�Ŏw�肳�ꂽ���������s����
        onTriggerStay.Invoke(other);
    }

    //UnityEvent���p�������N���X��[Serializable]������t�^���邱�ƂŁAInspector�E�B���h�E��ɕ\���ł���悤�ɂȂ�B
    [Serializable]
    public class TriggerEvent : UnityEvent<Collider>
    { }
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
