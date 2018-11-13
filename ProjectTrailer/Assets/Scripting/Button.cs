using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Button", menuName = "Button")]
public class Button : ScriptableObject {

    public float Velocity;
    public string SpawnPoint;
    public Sprite Image;
    public float Durability;
    public float TimeToSpawn;
    public string buttonToPress;
}
