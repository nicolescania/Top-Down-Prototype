using System.Collections;
using System.Collections.Generic;
using Assets.HeroEditor4D.Common.Scripts.CharacterScripts;
using Assets.HeroEditor4D.Common.Scripts.Enums;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectCollisions : MonoBehaviour
{

    [SerializeField] public bool isFollowing = false;
    private Camera mainCamera;
    public Character4D Character;



    [SerializeField] FloatingHealthBar healthBar;
    [SerializeField] float health, maxHealth;


    // Start is called before the first frame update
    void Start()
    {

        health = maxHealth;
        healthBar = mainCamera.GetComponentInChildren<FloatingHealthBar>();
        healthBar.UpdateHealthBar(health, maxHealth);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        healthBar.UpdateHealthBar(health, maxHealth);
  

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }



    


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1);
            //Character.AnimationManager.SetState(CharacterState.Jump);
            Debug.Log("chocaste un enemigo!");
            //RestarGame();
        }
    }




    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("FinalLevel"))
        {
            isFollowing = true; // Start following the player upon collision with the empty object
        }
    }

}
