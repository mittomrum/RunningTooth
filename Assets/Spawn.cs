using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject player;

    void Start()
    {
        player.transform.position = transform.position;    
    }
}
