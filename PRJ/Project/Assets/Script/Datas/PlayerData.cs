using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    public string Name;
    [Header("Character attributes")]
    public int MaxHealth;
    public int Health;
    public int Attack;
    public float MovementSpeed;
}
