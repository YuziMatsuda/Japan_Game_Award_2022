using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallFoor : MonoBehaviour
{
    //�@������������܂ł̎���
    [SerializeField] private float timeToFall = 5f;
    private Rigidbody rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //
    }

    public void OnCollisionEnter(Collision collision)
    {
        //�@�����������A�Փ˂����Q�[���I�u�W�F�N�g�̃��C���[��Field����������������
        if(collision.gameObject.layer == LayerMask.NameToLayer("MoveCubeGroup"))
        {
            Destroy(this.gameObject);
        }
    }
}
