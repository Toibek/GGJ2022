using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject arm;
    [SerializeField] private GameObject leg;
    [SerializeField] private float hingeSpeed;
    [SerializeField] private float slideSpeed;

    HingeJoint2D legHinge;
    SliderJoint2D legSlide;

    HingeJoint2D armHinge1;
    HingeJoint2D armHinge2;
    [SerializeField] private PlayerController otherPlayer;

    public bool ArmIsStunned = false;
    public bool LegIsStunned = false;

    private float armCooldown;
    private float legCooldown; 
    void Start()
    {
        if (CharacterManager.Instance.addController(this) == false)
            Destroy(gameObject);
        leg = CharacterManager.Instance.Leg(this);
        legHinge = leg.GetComponentInChildren<HingeJoint2D>();
        legSlide = leg.GetComponentInChildren<SliderJoint2D>();

        arm = CharacterManager.Instance.Arm(this);
        HingeJoint2D[] armHinges = arm.GetComponentsInChildren<HingeJoint2D>();
        armHinge1 = armHinges[0];
        armHinge2 = armHinges[1];
    }


    void Update()
    {

    }



    public void Move1(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                if (leg != null)
                {
                    legSlide.useMotor = true;
                    legHinge.useMotor = true;
                }
                break;
            case InputActionPhase.Performed:
                if (leg != null)
                {
                    Vector2 mov = (Vector2)context.ReadValueAsObject();

                    JointMotor2D hingeMotor = legHinge.motor;
                    hingeMotor.motorSpeed = -mov.x * hingeSpeed;
                    legHinge.motor = hingeMotor;

                    JointMotor2D slideMotor = legSlide.motor;
                    slideMotor.motorSpeed = mov.y * slideSpeed;
                    legSlide.motor = slideMotor;
                }
                break;
            case InputActionPhase.Canceled:
                if (leg != null)
                {
                    legSlide.useMotor = false;
                    legHinge.useMotor = false;
                }
                break;
            case InputActionPhase.Disabled:
                Debug.Log("Disabled");
                break;
            case InputActionPhase.Waiting:
                Debug.Log("Waiting");
                break;
        }
    }
    public void Move2(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                if (arm != null)
                {
                    armHinge1.useMotor = true;
                    armHinge2.useMotor = true;
                }
                break;
            case InputActionPhase.Performed:
                if (arm != null)
                {
                    Vector2 mov = (Vector2)context.ReadValueAsObject();

                    JointMotor2D hinge1Motor = armHinge1.motor;
                    hinge1Motor.motorSpeed = -mov.y * hingeSpeed;
                    armHinge1.motor = hinge1Motor;

                    JointMotor2D hinge2Motor = armHinge2.motor;
                    hinge2Motor.motorSpeed = mov.x * hingeSpeed;
                    armHinge2.motor = hinge2Motor;
                }
                break;
            case InputActionPhase.Canceled:
                if (arm != null)
                {
                    armHinge1.useMotor = false;
                    armHinge2.useMotor = false;
                }
                break;
            case InputActionPhase.Disabled:
                Debug.Log("Disabled");
                break;
            case InputActionPhase.Waiting:
                Debug.Log("Waiting");
                break;
        }
    }
    public void Action1(InputAction.CallbackContext context)
    {

    }
    public void Action2(InputAction.CallbackContext context)
    {

    }
    public void Action3(InputAction.CallbackContext context)
    {

    }
    public void Action4(InputAction.CallbackContext context)
    {

    }
    public void Join(InputAction.CallbackContext context)
    {

    }
}
