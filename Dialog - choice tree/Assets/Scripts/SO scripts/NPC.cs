using UnityEngine;

[CreateAssetMenu(fileName = "New Npc", menuName = "NPC")]
public class NPC : ScriptableObject
{
    
    [Tooltip("set ncp name")]
    public string npcName;

    [Tooltip("set position where to instantiate")]
    [SerializeField] private Vector3 startPos;
}
