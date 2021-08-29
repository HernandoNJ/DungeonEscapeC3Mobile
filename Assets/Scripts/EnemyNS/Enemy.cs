using UnityEngine;

namespace EnemyNS
{
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected Animator animator;
    [SerializeField] protected SpriteRenderer spriteRend;
    [SerializeField] protected int health, gems;
    [SerializeField] private float speed;
    [SerializeField] protected Transform pointA, pointB;
    [SerializeField] protected Vector3 currentTarget;
    
    public virtual void Init()
    {
        animator = GetComponentInChildren<Animator>();
        spriteRend = GetComponentInChildren<SpriteRenderer>();
        if(animator == null || spriteRend == null) Debug.LogWarning("Component missing in Enemy script");
    }

    protected void Start()
    {
        Init();
    }

    public virtual void Update()
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
            animator.SetTrigger("Idle");
        }
        else if (transform.position.x >= pointB.position.x)
        {
            currentTarget = pointA.position;
            animator.SetTrigger("Idle");
        }

        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
    }
}
}
