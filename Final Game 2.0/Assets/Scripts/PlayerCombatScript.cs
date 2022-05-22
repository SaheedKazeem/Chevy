﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MasterController;

public class PlayerCombatScript : MonoBehaviour
{
    public int maxHealth = 100, currentHealth;
    public HealthBarScript RefToHealthBar;
    public PlayerAnimator RefToPlayerAnimator;
    CapsuleCollider2D RefToKnockbackCollider;
    Knockback RefToKnockback;
   
    public Animator anim;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public float attackRate = 2f;
    float nextAttackTime;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        RefToHealthBar.SetMaxHealth(maxHealth);
        RefToKnockbackCollider = attackPoint.GetComponent<CapsuleCollider2D>();
        RefToKnockback = attackPoint.GetComponent<Knockback>();
        RefToKnockback.enabled = false;
        RefToKnockbackCollider.enabled = false;
       
        
    }
    
    
    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {

            if (Input.GetButtonDown("BKick"))
            {
                BabyKick();
                nextAttackTime = Time.time +1f / attackRate;
            }
            
        }

    }
    void BabyKick()
            {
                //Play Attack Animation
                anim.SetTrigger("isBabyKicking");
                // Detect enemies in range of attack
                RefToKnockbackCollider.enabled = true;
                RefToKnockback.enabled = true;
                Collider2D[] EnemiesHit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
                // Damage them
               
                foreach (Collider2D enemy in EnemiesHit)
                {
                    enemy.GetComponent<SlimeMobScript>().TakeDamage(25);
                }
                StartCoroutine(ColliderTimer(RefToKnockback,RefToKnockbackCollider));
            }
    public void TakeDamage(int Damage)
    {
        currentHealth -= Damage;
        RefToHealthBar.SetHealth(currentHealth);
        RefToPlayerAnimator.HasBeenDamaged();

    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    IEnumerator ColliderTimer(Knockback RefToKnockback, CapsuleCollider2D RefToKnockbackCollider)
    {
        if (attackPoint != null)
       {
           yield return new WaitForSeconds(0.5f);
           RefToKnockbackCollider.enabled = false;
            RefToKnockback.enabled = false;
       }
    }
}

