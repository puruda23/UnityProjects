using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// �ݶ��̴��� �ε����� �� ����Ʈ�� �������� ����
// �ݶ��̴� �ۿ� ������ ����Ʈ�� �������� ����
public class LightOnOff : MonoBehaviour
{
    public Light _light;
    private AudioSource source; // ����� �ҽ�
    public AudioClip _ligrtOnSound; // ����� Ŭ��
    public AudioClip _ligrtOffSound;
    private readonly string player = "Player";
    void Start()
    {
        _light = GetComponent<Light>();
       source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) // IsTrigger üũ�ǰ� �ݶ��̴� �ȿ� ��������
    {
        if (other.gameObject.CompareTag(player))
        {
            _light.enabled = true;
            source.PlayOneShot(_ligrtOnSound);
        }
    }
    private void OnTriggerExit(Collider other) // IsTrigger üũ�ǰ� �ݶ��̴����� ���� ��������
    {
        {
            if (other.gameObject.CompareTag(player))
            {
                _light.enabled = false;
                source.PlayOneShot(_ligrtOffSound);
            }

        }

        
    }
}
