﻿using System;
using UnityEngine;

public class Health : MonoBehaviour
{

    public float maxHealth = 255.0f;
    private float currentHealth;
    public PlayerHealthUI playerHealthUI;

    private void Start()
    {
        currentHealth = maxHealth;
        playerHealthUI.SetHealth(maxHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            currentHealth -= 15.0f;
            playerHealthUI.SetHealth(currentHealth);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0.0f)
        {
            currentHealth = 0.0f;
            Die();
        }
        playerHealthUI.SetHealth(currentHealth);
    }

    private void Die()
    {
        Debug.Log("you have died.");
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public float GetPlayerMaxHealth()
    {
        return maxHealth;
    }

    public void Heal(float healAmount)
    {
        currentHealth = currentHealth + healAmount > maxHealth ? maxHealth : currentHealth + healAmount;
        playerHealthUI.SetHealth(currentHealth);
    }
}
