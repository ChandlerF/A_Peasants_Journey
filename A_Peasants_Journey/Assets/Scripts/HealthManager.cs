using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{

    public float StartHealth;
    private float health;
    public static float PlayersDamage;
    public Drone alert;

    public Image HealthBar;

    void Start()
    {
        StartHealth = 100f; //temporary
        health = StartHealth;
    }

   
    void Update()
    {
        if (health <= 0)            //On Death do.....
        {
            Destroy(gameObject);
        }
    }


    public void DealDamage(float dmg)
    {
        health -= dmg;
        HealthBar.fillAmount = health / StartHealth;
    }

    private void OnTriggerEnter(Collider other)         //Taking Damage
    {
        if (other.tag == "PlayersWeapon")
        {
                DealDamage(PlayersDamage);      //Deals Damage
                alert.OnAware();        //Tells Enemy Where Player Is
                PlayersDamage = 0f;
        }
    }
}
