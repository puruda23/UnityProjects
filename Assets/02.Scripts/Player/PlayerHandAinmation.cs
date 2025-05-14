using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ���� ����Ʈ Ű�� WŰ�� ���ÿ� �������� ���� ���� �ִϸ��̼��� ����ϴ� ��ũ��ũ ����
// ���� ����Ʈ Ű�� WŰ�� ���߿� �ϳ��� ���� �ִϸ��̼��� ���߰� ���� �ܴ��� �ִϸ��̼��� ����ǵ��� ����
public class PlayerHandAinmation : MonoBehaviour
{
    public Animation anim;
    
    private readonly string runAni = "running";
    private readonly string runStopAni = "runStop";
    private readonly string fireAni = "fire";
    bool isRun;

    void Start()
    {
        // �ڱ��ڽ��� ù��° �ڽ� ������Ʈ�� ã�� �� �ڽ��� ������Ʈ�� �ڽ� ������Ʈ�� ã�´�
        anim = transform.GetChild(0).GetChild(0).GetComponent< Animation>(); // ��������
        //anim = GetComponentsInChildren<Animation>()[0]; // ���� �ڽ� �ִϸ��̼ǿ��� �ڽ� ������Ʈ�� ���ٸ�[]�ȿ� ������ �־� ã�´�
        //anim = GetComponentInChildren<Animation>();  // �ٸ� �ڽĿ��Ե� �ִϸ��̼����������־ �̷��Դ� �� �Ⱦ���
        isRun = false;
        
    }

    
    void Update()
    {
        PlayerRunAni();
        PlayerFire();

    }

    public void PlayerFire() // �Ѿ� �߻��ϴ� �ż��忡�� �ҷ����� ���� public ����
    {
        if (Input.GetMouseButton(0) && isRun == false) // ���Ҷ��� =�� �ΰ� ����Ѵ� isRun == false ��� !isRun �� �����ִ�
                                                       // �տ� ����ǥ�� �ٴ°��� �ݴ� ��� ǥ�ô� !false�� true��� ���̴�
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
