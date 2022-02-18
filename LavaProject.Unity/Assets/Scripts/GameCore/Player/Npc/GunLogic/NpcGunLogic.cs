using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcGunLogic : MonoBehaviour
{
    [SerializeField, Range(1, 10)] float _radiusOfAattack;
    [SerializeField]GameObject particles;
    private void Start()
    {
        particles = Resources.Load<GameObject>("Particles/Boom");
        _radiusOfAattack = 5; 
    }
    public void DoAttack(int power)
    {
        Effect();
        ApplyDamageToEnemies(power);
    }

    private void ApplyDamageToEnemies(int power)
    {
        Collider[] listOfNearColliders = Physics.OverlapSphere(transform.position, _radiusOfAattack);



        foreach (Collider victim in listOfNearColliders)
        {
            GameObject enemyOFNpc = victim.gameObject;
            Rigidbody _physicOfEnemy = enemyOFNpc.GetComponent<Rigidbody>() ? enemyOFNpc.GetComponent<Rigidbody>() : null;
            if (_physicOfEnemy != null)
            {
                _physicOfEnemy.AddForce(transform.forward * power, ForceMode.Impulse);
            }
        }
    }

    private void Effect()
    {
        var effect = Instantiate(particles, transform.position, transform.rotation);
        Destroy(effect, effect.GetComponent<ParticleSystem>().duration);
    }
}
