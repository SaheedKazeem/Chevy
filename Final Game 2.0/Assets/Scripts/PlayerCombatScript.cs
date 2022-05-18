using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatScript : MonoBehaviour
{
    public int maxHealth = 100, currentHealth;
    public HealthBarScript RefToHealthBarScript; 
    public Animator anim;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    // Start is called before the first frame update
    void Start() 
    {
        currentHealth = maxHealth;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            BabyKick();
        }
        void BabyKick()
        {
            //Play Attack Animation
            anim.SetTrigger("isBabyKicking");
            // Detect enemies in range of attack
            Collider2D[] EnemiesHit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            // Damage them
            foreach (Collider2D enemy in EnemiesHit)
            {
                Debug.Log("We hit " + enemy.name);
            }
        }

    }
    public void TakeDamage(int Damage)
    {
        currentHealth -= Damage;
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

