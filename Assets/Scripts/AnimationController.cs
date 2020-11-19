using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    public Animator animator;

    List<string> animlist = new List<string>(new string[] { "Animation 1", "Animation 2", "Animation 3"});
    List<string> spellList = new List<string>(new string[] { "Cast Spell", "Two Hand Cast" });
    public int combonum;
    public float reset;
    public float resetTime;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetButtonDown("Fire1") && combonum < 3)
        {
            animator.SetTrigger(animlist[combonum]);
            combonum++;
            reset = 0f;
        }
       if (combonum > 0)
        {
            reset += Time.deltaTime;
            if (reset > resetTime)
            {
                animator.SetTrigger("Reset");
                combonum = 0;
            }
        }
       if (combonum == 3)
        {
            resetTime = 3f;
            combonum = 0;
        }
        else
        {
            resetTime = 1f;
        }

       if (Input.GetKey("w"))
        {
            animator.SetBool("IsWalking", true);
        }

        if (!Input.GetKey("w"))
        {
            animator.SetBool("IsWalking", false);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            animator.SetTrigger("Cast Spell");
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            animator.SetTrigger("Two Hand Cast");
        }
    }
}
