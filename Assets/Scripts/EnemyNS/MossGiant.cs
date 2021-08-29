using System;
using UnityEngine;

namespace EnemyNS
{
public class MossGiant : Enemy
{
    [SerializeField] private Vector3 currentTarget;
    private Animator animator;
    private SpriteRenderer spriteRend;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        spriteRend = GetComponentInChildren<SpriteRenderer>();
    }

    public override void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle")) return;
        Move();
    }

    private void Move()
    {
        if (currentTarget == pointA.position) spriteRend.flipX = true;
        if (currentTarget == pointB.position) spriteRend.flipX = false;
        
        if (transform.position.x <= pointA.position.x)
        {
            currentTarget = pointB.position;
            animator.SetTrigger("idleTrigger");
        }
        else if (transform.position.x >= pointB.position.x)
        {
            currentTarget = pointA.position;
            animator.SetTrigger("idleTrigger");
        }

        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
    }
}
}
