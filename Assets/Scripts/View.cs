using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{

    [SerializeField] PlayerStats myStats;
    [SerializeField] Image healthBar;

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = (1.0f * myStats.health) / myStats.maxHealth;
    }
}
