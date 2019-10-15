using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DM;

public class ThirdPersonController : MonoBehaviour {


    public float moveSpeed = 10;
    public float sprintSpeed = 12;
    public float airSpeedModifier = 0.01f;
    public float jumpForce = 6;
    public float rotateSpeed = 5;
    public GameObject activeModel;
    internal Rigidbody rb;
    private Animator anim;
    internal bool onGround;
    internal bool canMove;
    private bool sprint;
    private Vector3 previousVelocity;

    private List<InteractableObj> _InterObjs = new List<InteractableObj>();

    /*
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        SetupAnimator();
        CameraManager.singleton.Init(this.transform);
    }

    void SetupAnimator()
    {
        if (activeModel == null)
        {
            anim = GetComponentInChildren<Animator>();
            if (anim == null)
            {
                Debug.Log("No model");
            }
            else
            {
                activeModel = anim.gameObject;
            }
        }

        if (anim == null)
            anim = activeModel.GetComponent<Animator>();

        if (anim == null)
            anim = activeModel.AddComponent<Animator>();
    }

    private void Update()
    {
        onGround = OnGround();
        canMove = CanMove();
    }

    // Update is called once per frame
    void FixedUpdate () {

        CameraManager.singleton.FixedTick(Time.fixedDeltaTime);
        //TODO:动画状态的切换
        anim.SetBool("onGround", onGround);
        MovementHandler();

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            anim.CrossFade("falling", 0.1f);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Force);
            previousVelocity = rb.velocity;
        }

        if(Input.GetKeyDown(KeyCode.Q) && onGround)
        {
            anim.SetTrigger("roll");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            //交互
            if(_InterObjs.Count != 0)
            {
                Debug.Log("Hi，NPC！");
                UIManager.Instance.Push<UIScreenDialogue>(UIDepthConst.TopDepth, false, 1001);
                _InterObjs[0].OnInteracted(this);
            }
        }
    }

    private void MovementHandler()
    {
        sprint = Input.GetKey(KeyCode.LeftShift);
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float realSpeed = sprint ? sprintSpeed : moveSpeed;
        Vector3 moveDir;
        if (canMove)
        {
            moveDir = (transform.forward * verticalInput + transform.right * horizontalInput);
            //如果当前移速大小超过1，需要进行约束，不然会出现同时按住左右和上下的某个方向导致速度为朝某个方向的根号2倍
            //这里有sqrMagnitude判断的原因是，开根号运算比较耗时，对于这里只需要比较大小，只需要知道平方即可。
            if(moveDir.sqrMagnitude > 1)
            {
                moveDir = moveDir.normalized;
            } 
            moveDir *= realSpeed;
        }
        else
        {
            //在空中移动的控制需要在原有的速度的基础上叠加
            Vector3 modifier = (transform.forward * verticalInput + transform.right * horizontalInput).normalized * realSpeed * airSpeedModifier;

            moveDir = Vector3.Dot(modifier, rb.velocity) > 0 ? rb.velocity : rb.velocity + modifier;
        }
        rb.velocity = new Vector3(moveDir.x, rb.velocity.y, moveDir.z);
        float moveAmount = Mathf.Clamp01(rb.velocity.magnitude);
        Quaternion targetRotation = Quaternion.LookRotation(CameraManager.singleton.transform.forward, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.fixedDeltaTime * moveAmount * rotateSpeed);
        anim.SetFloat("vertical", moveAmount, 0.2f, Time.fixedDeltaTime);
        anim.SetBool("sprint", sprint);

    }

    private bool CanMove()
    {
        if (!onGround)
            return false;
        if (!anim.GetBool("canMove"))
            return false;
        return true;
    }

    //只有玩家处在地面上时才能够跳跃。
    private bool OnGround()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down, out hit, 0.2f, 1 << 11))
        {
            if(hit.transform.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                return true;
            }
        }
        return false;


    }



    //只有玩家周围有能够交互的物体或者npc时才能够使用交互。
    private void OnTriggerEnter(Collider other)
    {
        InteractableObj otherInter = other.gameObject.GetComponent<InteractableObj>();
        if (otherInter != null)
        {
            _InterObjs.Add(otherInter);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        InteractableObj otherInter = other.gameObject.GetComponent<InteractableObj>();
        if (otherInter != null)
        {
            if(_InterObjs.Contains(otherInter))
                _InterObjs.Remove(otherInter);
            else
            {
                Debug.LogWarning("意料之外的问题！");
            }
        }
    }
    */
}
