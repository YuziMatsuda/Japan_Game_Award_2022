using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallFoor : MonoBehaviour
{
    //�@������������܂ł̎���
    [SerializeField] private float timeToFall = 5f;
    //�@��l�������ɏ���Ă����g�[�^������
    private float totalTime = 0f;
    private Rigidbody rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        //�@�����������鎞�Ԃ𒴂����烊�W�b�h�{�f�B��isKinematic��false��
        //�@isKinematic��false�ɂ������Ƃŏd�͂�����
        if(totalTime >= timeToFall)
        {
            rigid.isKinematic = false;
        }
    }

    //�@��l�������ɏ���Ă��鎞�ɌĂяo��
    public void ReceiveForce()
    {
        totalTime += Time.deltaTime;
    }

    public void OnCollisionEnter(Collision collision)
    {
        //�@�����������A�Փ˂����Q�[���I�u�W�F�N�g�̃��C���[��Field����������������
        if(collision.gameObject.layer == LayerMask.NameToLayer("Field"))
        {
            Destroy(this.gameObject, 1f);
        }
    }
}
