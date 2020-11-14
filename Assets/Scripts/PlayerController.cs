using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;

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

        Vector3 direction = new Vector3(x, 0f, z).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            controller.Move(moveDirection.normalized * speed * Time.deltaTime);

            GetComponent<Animator>().Play("Walking");
        }

        if (Input.GetKey(KeyCode.Z))
        {
            ChargeEnergy(2);
        }

        if (Input.GetKey(KeyCode.H))
        {
            LoseEnergy(4);
        }
    }

    void ChargeEnergy(int charge)
    {
        currentEnergy += charge;

        energyBar.SetEnergy(currentEnergy);
    }

    void LoseEnergy(int lose)
    {
        currentEnergy -= lose;

        energyBar.SetEnergy(currentEnergy);
    }
}
