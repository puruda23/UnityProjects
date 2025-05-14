using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// FŰ�� ������ ����Ʈ�� ������ �ٽ� FŰ�� ������ ������
// ���� ������ ���� : audiosource, audiClip
public class FiashLight : MonoBehaviour
{
    [SerializeField] private Light fiashLight;
    [SerializeField] private AudioSource source;
    public AudioClip fiashclip;


    void Start()
    {
        fiashLight = GetComponent<Light>();
        source = GetComponent<AudioSource>();

    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            fiashLight.enabled = !fiashLight.enabled; // FŰ�� ���������� true false �� �ٲ��
            source.PlayOneShot(fiashclip,1.0f);
        }
        

    }
}
