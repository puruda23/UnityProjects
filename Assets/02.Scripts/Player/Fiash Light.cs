using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// F키를 누르면 라이트가 켜지고 다시 F키를 누르면 꺼진다
// 사운드 구현도 같이 : audiosource, audiClip
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
            fiashLight.enabled = !fiashLight.enabled; // F키를 누를때마다 true false 가 바뀐다
            source.PlayOneShot(fiashclip,1.0f);
        }
        

    }
}
