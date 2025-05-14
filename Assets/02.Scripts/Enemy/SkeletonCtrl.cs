using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonCtrl : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Transform skeletonTr;
    [SerializeField] private NavMeshAgent navi;
    public float traceDist = 20.0f; // ���� �Ÿ�
    public float attackDist = 3.0f; // ���� ����
    public Transform playerTr;
    private readonly int hashAttack = Animator.StringToHash("IsAttack"); // �ִϸ��̼� ����ȭ ""ǥ�� ���ִ� ���
                 // �����Ҵ�� ���� ���ڿ��� �о ������ ��ȯ
    private readonly int hasTrace = Animator.StringToHash("IsTrace");
    
    void Start()
    {
        animator = GetComponent<Animator>();
        navi = GetComponent<NavMeshAgent>();
        playerTr = GameObject.FindWithTag("Player").transform; // �ѹ��� �ϰ� �������� ���� ����ȭ�� ���Ѵ�
        skeletonTr = GetComponent<Transform>();
    }

    
    void Update()
    {
        float dist = Vector3.Distance(skeletonTr.position, playerTr.position);
        if (dist < attackDist) // �������϶�
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
            animator.SetBool(hasTrace, false);
            navi.isStopped = true; // ó�� ���� ���� �� ����
        }
    }
}
