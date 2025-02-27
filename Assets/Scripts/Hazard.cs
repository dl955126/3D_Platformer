using UnityEngine;

public class Hazard : MonoBehaviour
{
    [SerializeField] Player player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //on collision take damage
    private void OnTriggerEnter(Collider collision)
    {
        player.Damage();
    }
}
