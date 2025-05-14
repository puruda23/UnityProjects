using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 콜라이더에 부딪혔을 때 라이트가 켜지도록 구현
// 콜라이더 밖에 나가면 라이트가 꺼지도록 구현
public class LightOnOff : MonoBehaviour
{
    public Light _light;
    private AudioSource source; // 오디오 소스
    public AudioClip _ligrtOnSound; // 오디오 클립
    public AudioClip _ligrtOffSound;
    private readonly string player = "Player";
    void Start()
    {
        _light = GetComponent<Light>();
       source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) // IsTrigger 체크되고 콜라이더 안에 들어왔을때
    {
        if (other.gameObject.CompareTag(player))
        {
            _light.enabled = true;
            source.PlayOneShot(_ligrtOnSound);
        }
    }
    private void OnTriggerExit(Collider other) // IsTrigger 체크되고 콜라이더에서 빠져 나왔을때
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
