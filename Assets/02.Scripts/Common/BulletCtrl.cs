using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// �ڱ��ڽ� ������ Z������ ���� �̵��Ѵ�
public class BulletCtrl : MonoBehaviour
{
    public float Speed = 1500;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * Speed); // Vector3 �� �ƴ϶� ���� ��ǥ�� �ؾ��Ѵ�

    }

    
    
}
