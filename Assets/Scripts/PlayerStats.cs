using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Player's Stats")] 

public class PlayerStats : ScriptableObject
{
    public int health;
    public int maxHealth;
    public int moveSpeed;
    public int jumpForce;
    public int gravity;


}
