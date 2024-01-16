using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attribute : MonoBehaviour
{
    private ColorOverlay ColorOverlay;
    // public string Status;
    public int MaxHealth;
    public int Health;
    public int Attack;
    public float MovementSpeed;

    private void Awake()
    {
        ColorOverlay = GetComponent<ColorOverlay>();
    }
    public void TakeDamage(int damage)
    {
        Health -= damage;
        ColorOverlay.ApplyFlashColor(Color.red);
        if (Health <= 0)
        {
            Health = 0;
        }
    }
    public void DealDamage(GameObject gameObject)
    {
        Attribute attribute = gameObject.GetComponent<Attribute>();
        if (attribute != null)
        {
            attribute.TakeDamage(Attack);
        }
    }
}
