using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerStats
{
    public static string epithet = "";

    [Header ("HP")]
    public static float maxHealth = 300f;
    public static float currentHealth = maxHealth;
    public static bool dead = false;

    [Header ("Movement")]
    public static float moveSpeed = 5f;
    public static int maxJumpCount = 1;
    // public static float jumpHeight = 0.6f;

    [Header ("Combat")]
    public static float strength = 3f;
    public static float basicDamage = 1f;
    public static float knockbackStrength = 15f;
    public static float basicAttackRate = 2f;


    [Header ("Lifetime")]
    public static float enemiesSlain = 0;
    public static int areasCleared = 0;



    public static float money = 50;

    

 





    



    public static float critInstaKillSuperRealEpicMechanic = 0.0000000000001f;

    

}
