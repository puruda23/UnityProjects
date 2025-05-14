using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainStop : MonoBehaviour
{
    public GameObject rainPrefab; // �� ������
    public GameObject rainObj; // �� ������Ʈ
    private readonly string player = "Player";
    void Start()
    {
        rainObj = Instantiate(rainPrefab); // �� �������� �ν��Ͻ�ȭ�Ͽ� rainObj�� ����
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(player))
        {
            Destroy(rainObj); // �� ������Ʈ ����
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag(player))
        {
            rainObj = Instantiate (rainPrefab); // �� �������� �ν��Ͻ�ȭ�Ͽ� rainObj����
        }
    }


}
