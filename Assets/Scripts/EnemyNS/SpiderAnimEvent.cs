using UnityEngine;

namespace EnemyNS
{
public class SpiderAnimEvent : MonoBehaviour
{
    [SerializeField] private Spider spider;
    [SerializeField] private GameObject acid;

    public void FireAcid()
    {
        spider.SpiderAttack();
    }
}
}
