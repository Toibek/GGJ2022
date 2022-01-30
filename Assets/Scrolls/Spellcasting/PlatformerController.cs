using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerController : MonoBehaviour
{
    [SerializeField] GameObject prefabCharacter;
    [SerializeField] float movSpeed;
    [SerializeField] float jumpForce;

    Transform spawnpoint;
    GameObject Character;
    Transform charTrans;
    Rigidbody2D charRb;
    Animator CharAnim;
    GroundCheck charGround;

    public static PlatformerController Instance;
    #region Singleton
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }
    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }
    #endregion
    public PlayerController[] Players = new PlayerController[2];
    public bool addController(PlayerController cont)
    {
        for (int i = 0; i < Players.Length; i++)
        {
            if (Players[i] == null)
            {
                Players[i] = cont;
                return true;
            }
        }
        return false;
    }

    private void Start()
    {
        spawnpoint = GameObject.Find("Spawnpoint").transform;
        spawnCharacter();
    }
    void spawnCharacter()
    {
        Character = Instantiate(prefabCharacter, spawnpoint.position, Quaternion.identity);
        charTrans = Character.transform;
        charRb = Character.GetComponent<Rigidbody2D>();
        CharAnim = Character.GetComponent<Animator>();
        charGround = Character.GetComponent<GroundCheck>();
    }
    private void Update()
    {
        HandleMovement();
    }
    private void HandleMovement()
    {
        if (Players[0] && Players[1])
        {
            Vector2 totalMovement = (Players[0].Movement + Players[1].Movement).normalized;
            charRb.velocity = new Vector2(totalMovement.x * movSpeed,charRb.velocity.y);
            if (totalMovement.y > 0.5f && charGround.Grounded)
                charRb.velocity = new Vector2(charRb.velocity.x, jumpForce);

        }
    }
}
