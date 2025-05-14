using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 자기자신 스스로 Z축으로 빨리 이동한다
public class BulletCtrl : MonoBehaviour
{
    public float Speed = 1500;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * Speed); // Vector3 가 아니라 절대 좌표로 해야한다

    }

    
    
}
