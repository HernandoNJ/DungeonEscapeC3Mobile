using Interfaces;
using UnityEngine;

namespace EnemyNS
{
public abstract class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] protected Player player;
    [SerializeField] protected Animator animator;
    [SerializeField] protected SpriteRenderer spriteRend;
    [SerializeField] protected Transform pointA, pointB;
    [SerializeField] protected Vector3 currentTarget;
    [SerializeField] protected int health, gems;
    [SerializeField] protected bool isHit;
    [SerializeField] private float speed;
    
    public int Health{ get; set; }

    protected void Start()
    {
        Init();
    }

    public virtual void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") &&
            animator.GetBool("inCombat") == false) return;
        EnemyMove();
    }
    
    public virtual void Init()
    {
        Health = health;
        animator = GetComponentInChildren<Animator>();
        spriteRend = GetComponentInChildren<SpriteRenderer>();
        if(animator == null || spriteRend == null) Debug.LogWarning("Component missing in Enemy script");
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    protected virtual void EnemyMove()
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

        if (isHit == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        }
    }

    public virtual void Damage(int damageAmount)
    {
        Health -= damageAmount;
        if(Health <1) Destroy(gameObject);
    }
}
}
