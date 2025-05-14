using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
// NavMeshAgent�� �̿��Ͽ�
// �÷��̾ �������� �ȿ� ������ �����ϰ�
// ���� �����ȿ� ������ �����ϴ� ���� ������ �ִϸ��̼� ����
// �������� ���ݹ����� ���Ϸ��� �Ÿ��� ���ؾ��� �÷��̾�� ������ ��ġ�� �˾ƾ���
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent (typeof(Animator))] // �Ǽ��� �����Ǵ°� ����
public class ZombieCtrl : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Transform zomBieTr;
    [SerializeField] private NavMeshAgent navi;
    public float traceDist = 20.0f; // ���� �Ÿ�
    public float attackDist = 2.0f; // ���� ����
    public Transform playerTr;
    private readonly int hashAttack = Animator.StringToHash("IsAttack");
    private readonly int hasTrace = Animator.StringToHash("IsTrace");
    
    void Start()
    {
        animator = GetComponent<Animator>();
        navi = GetComponent<NavMeshAgent>();
        playerTr = GameObject.FindWithTag("Player").transform;  
        zomBieTr = GetComponent<Transform>();
        // �빮�� GameObject�� ���̶�Ű���� Player��� �±׸� ���� ������Ʈ�� Ʈ�������� ������
    }


    void Update()
    {
        float dist = Vector3.Distance(zomBieTr.position,playerTr.position);
        if(dist < attackDist) // �������϶�
        {
            animator.SetBool(hashAttack, true);
            navi.isStopped = true; // �������϶� �׺� ��������
        }
        else if (dist < traceDist)
        {
            animator.SetBool(hashAttack, false);
            animator.SetBool(hasTrace, true);
            navi.isStopped = false; // ���� ���� �ȿ� ������ �׺� ���� ����
            navi.destination = playerTr.position; // �÷��̾��� ��ġ�� �������� ����
        }
        else // ���ݵ� �ƴϰ� ������ �ƴҶ�
        {
            animator. SetBool(hasTrace, false);
            navi.isStopped = true; // ó�� ���� ���� �� ����
        }

    }
}
