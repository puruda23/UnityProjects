using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
// NavMeshAgent를 이용하여
// 플레이어가 추적범위 안에 들어오면 추적하고
// 공격 범위안에 들어오면 공격하는 로직 구현과 애니메이션 연동
// 추적범위 공격범위를 구하려면 거리를 구해야함 플레이어랑 좀비의 위치를 알아야함
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent (typeof(Animator))] // 실수로 샂제되는걸 방지
public class ZombieCtrl : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Transform zomBieTr;
    [SerializeField] private NavMeshAgent navi;
    public float traceDist = 20.0f; // 추적 거리
    public float attackDist = 2.0f; // 공격 범위
    public Transform playerTr;
    private readonly int hashAttack = Animator.StringToHash("IsAttack");
    private readonly int hasTrace = Animator.StringToHash("IsTrace");
    
    void Start()
    {
        animator = GetComponent<Animator>();
        navi = GetComponent<NavMeshAgent>();
        playerTr = GameObject.FindWithTag("Player").transform;  
        zomBieTr = GetComponent<Transform>();
        // 대문자 GameObject는 하이라키에서 Player라는 태그를 가진 오브젝트의 트랜스폼을 가져옴
    }


    void Update()
    {
        float dist = Vector3.Distance(zomBieTr.position,playerTr.position);
        if(dist < attackDist) // 공격중일때
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
            animator. SetBool(hasTrace, false);
            navi.isStopped = true; // 처적 범위 밖일 때 정지
        }

    }
}
