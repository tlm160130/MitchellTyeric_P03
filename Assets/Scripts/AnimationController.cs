using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    public Animator animator;

    List<string> animlist = new List<string>(new string[] { "Animation 1", "Animation 2", "Animation 3" });
    List<string> kicklist = new List<string>(new string[] { "Animation 4", "Animation 5"});
    public int combonum;
    public float reset;
    public float resetTime;

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Mouse0) && combonum < 3)
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

        if (Input.GetKeyDown(KeyCode.Mouse1) && combonum < 2)
        {
            animator.SetTrigger(kicklist[combonum]);
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
        if (combonum == 2)
        {
            resetTime = 3f;
            combonum = 0;
        }
        else
        {
            resetTime = 1f;
        }
    }
}
