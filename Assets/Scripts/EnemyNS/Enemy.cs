using System;
using UnityEngine;

namespace EnemyNS
{
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health,speed,gems;
    [SerializeField] protected Transform pointA, pointB;

    public virtual void Update()
    {
        
    }
}
}
