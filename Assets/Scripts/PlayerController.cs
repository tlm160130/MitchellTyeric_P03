using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;
    public ParticleSystem chargeLight;
    public AudioSource chargeAudio;
    public AudioSource menuOpenSound;
    public AudioSource menuCloseSound;

    public GameObject SpecialAttack2UI;

    public int maxHealth = 100;
    public int currentHealth;

    public int maxEnergy = 100;
    public int currentEnergy;

    public HealthBar healthBar;
    public EnergyBar energyBar;

    public Transform cam;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;

    private float turnSmoothVelocity;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();


        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        currentEnergy = maxEnergy;
        energyBar.SetMaxEnergy(maxEnergy);
    }

    // Update is called once per frame
    void Update()
    {

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z; //Moves based on x and z movement and where the player is facing
        //don't want to use new Vector3() because those are GLOBAL Coordinates

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool("IsWalking", true);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("IsWalking", false);
        }

        if (Input.GetKey(KeyCode.B))
        {
            ChargeEnergy(2);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Super2(20);
            animator.SetTrigger("Two Hand Cast");
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ShowSpecials();
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            StopShowingSpecials();
        }
    }

    void ChargeEnergy(int charge)
    {
        currentEnergy += charge;

        energyBar.SetEnergy(currentEnergy);

        chargeLight.Play();
        chargeAudio.Play();
    }

    void Super2(int lose)
    {
        currentEnergy -= lose;

        energyBar.SetEnergy(currentEnergy);
    }

    void ShowSpecials()
    {
        SpecialAttack2UI.SetActive(true);
        menuOpenSound.Play();
    }

    void StopShowingSpecials()
    {
        SpecialAttack2UI.SetActive(false);
        menuCloseSound.Play();
    }
}
