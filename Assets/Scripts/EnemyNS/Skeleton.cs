using UnityEngine;

namespace EnemyNS
{
public class Skeleton : Enemy
{
    protected override void EnemyMove()
    {
        base.EnemyMove();
        var dist = Vector3.Distance(gameObject.transform.localPosition, player.transform.localPosition);
        if (dist > 2f) 
        { isHit = false; animator.SetBool("inCombat", false);}
        //direction = player pos - enemy pos (target - origin)
        var direction = player.transform.localPosition - transform.localPosition;
        
        //direction.x: if positive, player is at right, else it is at left
        if (direction.x > 0 && animator.GetBool("inCombat") == true) spriteRend.flipX = false;
        else if (direction.x < 0 && animator.GetBool("inCombat") == true) spriteRend.flipX = true;

    }

    public override void Damage(int damageAmount)
    {
        base.Damage(damageAmount);
        animator.SetTrigger("Hit");
        isHit = true;
        animator.SetBool("inCombat", true);
    }
}
}
