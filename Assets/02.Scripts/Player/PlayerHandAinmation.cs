using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 왼쪽 쉬프트 키와 W키를 동시에 눌렀을때 총을 접는 애니메이션을 재생하는 스크립크 구현
// 왼쪽 쉬프트 키와 W키를 둘중에 하나라도 때면 애니메이션을 멈추고 총을 겨누는 애니메이션이 재생되도록 구현
public class PlayerHandAinmation : MonoBehaviour
{
    public Animation anim;
    
    private readonly string runAni = "running";
    private readonly string runStopAni = "runStop";
    private readonly string fireAni = "fire";
    bool isRun;

    void Start()
    {
        // 자기자신의 첫번째 자식 오브젝트를 찾고 그 자식의 오브젝트의 자식 오브젝트를 찾는다
        anim = transform.GetChild(0).GetChild(0).GetComponent< Animation>(); // 가독성이
        //anim = GetComponentsInChildren<Animation>()[0]; // 복수 자식 애니메이션에서 자식 오브젝트가 많다면[]안에 순번을 넣어 찾는다
        //anim = GetComponentInChildren<Animation>();  // 다른 자식에게도 애니메이션이있을수있어서 이렇게는 잘 안쓴다
        isRun = false;
        
    }

    
    void Update()
    {
        PlayerRunAni();
        PlayerFire();

    }

    public void PlayerFire() // 총알 발사하는 매서드에서 불러오기 위해 public 선언
    {
        if (Input.GetMouseButton(0) && isRun == false) // 비교할때는 =을 두개 써야한다 isRun == false 대신 !isRun 을 쓸수있다
                                                       // 앞에 느낌표가 붙는것은 반대 라는 표시다 !false는 true라는 뜻이다
        {
            anim.Play(fireAni);
        }
    }

    private void PlayerRunAni()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            anim.Play(runAni);
            isRun = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.Play(runStopAni);
            isRun = false;
        }
    }
}
