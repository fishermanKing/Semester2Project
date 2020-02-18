using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Start is called before the first frame update
    public float restPosition = 0f;
    public float pressedPosition = 40f;
    public float hitStrength = 10000f;
    public float flipperDamper = 150f;
    HingeJoint hinge;

    public enum Flipper { LeftFlip, RightFlip };
    public Flipper FlipperSide;
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        hinge.useSpring = true;
    }

    // Update is called once per frame
    void Update()
    {
        JointSpring spring = new JointSpring();
        spring.spring = hitStrength;
        spring.damper = flipperDamper;
        if (Input.GetButton(FlipperSide.ToString()))
        {
            //spring.targetPosition = restPosition;
            spring.targetPosition = pressedPosition;
        }
        else
        {
            //spring.targetPosition = pressedPosition;
            spring.targetPosition = restPosition;
        }
        hinge.spring = spring;
        hinge.useLimits = true;
    }
}
