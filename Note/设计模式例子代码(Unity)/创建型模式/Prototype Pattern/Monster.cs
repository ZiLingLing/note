using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : BaseClone<Monster>
{

    public string enemyName;
    public int health;
    public int damage;
    public Material material;
    public MeshFilter meshFilter;

    public void DisplayInfo()
    {
        Debug.Log($"Enemy: {enemyName}, Health: {health}, Damage: {damage}");
    }
}


