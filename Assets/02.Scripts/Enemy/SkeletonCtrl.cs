using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonCtrl : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Transform skeletonTr;
    [SerializeField] private NavMeshAgent navi;
    public float traceDist = 20.0f; // 추적 거리
    public float attackDist = 3.0f; // 공격 범위
    public Transform playerTr;
    private readonly int hashAttack = Animator.StringToHash("IsAttack"); // 애니메이션 최적화 ""표를 없애는 방법
                 // 동적할당과 동시 문자열을 읽어서 정수로 변환
    private readonly int hasTrace = Animator.StringToHash("IsTrace");
    
    void Start()
    {
        animator = GetComponent<Animator>();
        navi = GetComponent<NavMeshAgent>();
        playerTr = GameObject.FindWithTag("Player").transform; // 한번만 하고 지나가서 굳이 최적화를 안한다
        skeletonTr = GetComponent<Transform>();
    }

    
    void Update()
    {
        float dist = Vector3.Distance(skeletonTr.position, playerTr.position);
        if (dist < attackDist) // 공격중일때
        {
            animator.SetBool(hashAttack, true);
            navi.isStopped = true; // 공격중일때 네비 추적정지
        }
        else if (dist < traceDist)
        {
            animator.SetBool(hashAttack, false);
            animator.SetBool(hasTrace, true);
            navi.isStopped = false; // 추적 범위 안에 들어오면 네비 추적 시작
            navi.destination = playerTr.position; // 플레이어의 위치를 목적지로 설정
        }
        else // 공격도 아니고 추적도 아닐때
        {
            animator.SetBool(hasTrace, false);
            navi.isStopped = true; // 처적 범위 밖일 때 정지
        }
    }
}
