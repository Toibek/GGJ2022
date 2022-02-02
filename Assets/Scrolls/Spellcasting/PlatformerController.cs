using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
    public void addController(PlayerInput input)
    {
        PlayerController cont = input.GetComponent<PlayerController>();
        for (int i = 0; i < Players.Length; i++)
        {
            if (Players[i] == null)
            {
                Players[i] = cont;
                StartCoroutine(legMovement(i));
                break;
            }
        }
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
            if (Mathf.Abs(totalMovement.x) > 0.2f)
                charRb.velocity = new Vector2(totalMovement.x * movSpeed, charRb.velocity.y);
            else
                charRb.velocity = new Vector2(0, charRb.velocity.y);
            if (totalMovement.y > 0.5f && charGround.Grounded)
                charRb.velocity = new Vector2(charRb.velocity.x, jumpForce);

        }
    }
    IEnumerator legMovement(int controller)
    {
        float stepDis = 0.4f;
        float stepHeight = 0.2f;
        Transform leg = charTrans.GetChild(controller).Find("Leg");

        Vector2 origin = leg.localPosition;

        float lerp = 1;
        float start = 0;
        float end = 0;
        while (Character != null)
        {
            float mov = Players[controller].Movement.x;
            float dis = origin.x - leg.localPosition.x;
            if (lerp < 1)
            {
                float footPosition = origin.x + Mathf.Lerp(start, end, lerp);
                float footHeight = origin.y + Mathf.Sin(lerp * Mathf.PI) * stepHeight;

                leg.localPosition = new Vector2(footPosition, footHeight);
                lerp += Time.deltaTime * movSpeed;
            }
            else if (Mathf.Abs(dis) >= stepDis)
            {
                lerp = 0;
                start = leg.localPosition.x - origin.x;
                end = (stepDis * 0.9f) * Mathf.Sign(dis);
            }
            else
            {
                leg.localPosition += new Vector3(-mov * 2 * Time.deltaTime, 0);
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
