using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerInput), typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public GameObject footstepA;
    public GameObject footstepB;

    [SerializeField] private float playerSpeed;
    [SerializeField] private GameSettings gamesettings;

    private CharacterController playerController;

    private float runSpeed;
    private float runTime = 2f;

    public TMP_Text Life_Text;
    public Image Lebens_Img;
    public int Life = 100;

    bool canNotGetDmg;

    private Vector2 move;
    private Vector2 look;
    private UnityEngine.Vector3 playerVelocity;

    private MouseLook[] mouselook;

    private bool jumped;
    private bool running;
    [SerializeField] private bool isGrounded;
    public static bool triggered { get; private set; }
    public static bool openMenu { get; private set; }
    public static bool openShopMenu { get; private set; }

    public static int getInput { get; private set; }
    private float timer = 0;
    public int audioTurn = 0;


    #region InputActions

    /// <summary>
    /// enables interaction with buttons{keycode.E} _ {ButtonWest/Gamepad}
    /// </summary>
    /// <param name="context"></param>
    public void OnInteract(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                triggered = true;
                getInput = 1;
                break;
            case InputActionPhase.Canceled:
                triggered = false;
                getInput = 0;
                break;
        }
    }

    /// <summary>
    /// enables movement W,A,S,D _ leftstick(Gamepad)
    /// </summary>
    /// <param name="context"></param>
    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();

    }

    /// <summary>
    /// enables cameramovement mouse _ rightstick
    /// </summary>
    /// <param name="context"></param>
    public void OnLook(InputAction.CallbackContext context)
    {
        look = context.ReadValue<Vector2>();
    }

    /// <summary>
    /// enables running, because dashing doesnt work 
    /// </summary>
    /// <param name="context"></param>
    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.started)
            running = true;
        else if (context.canceled)
            running = false;
    }

    /// <summary>
    /// enables jumping, spacebar _ ButtonSouth(Gamepad)
    /// </summary>
    /// <param name="context"></param>
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
            jumped = true;
        else if (context.canceled)
            jumped = false;
    }

    /// <summary>
    /// enables the Menu with, Escape _ startButton(Gamepad)
    /// </summary>
    /// <param name="context"></param>
    public void OnOpenMenu(InputAction.CallbackContext context)
    {
        if (context.started)
            openMenu = true;
        else if (context.canceled)
            openMenu = false;
    }

    public void OnOpenShopMenu(InputAction.CallbackContext context)
    {
        if (context.started)
            openShopMenu = true;
        else if (context.canceled)
            openShopMenu = false;
    }

    #endregion

    private void Awake()
    {
        Aktualisier_Life();
        playerController = GetComponent<CharacterController>();
        mouselook = GetComponentsInChildren<MouseLook>();
    }

    /// <summary>
    /// moves player in the direction of the input
    /// </summary>
    /// <param name="direction"></param>
    private void Move(Vector2 direction)
    {
        
        

        isGrounded = playerController.isGrounded;
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0;
        }


        UnityEngine.Vector3 _move = new UnityEngine.Vector3(direction.x, 0, direction.y);
        playerController.Move(transform.TransformDirection(_move) * Time.deltaTime * playerSpeed);

        if (jumped && isGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(gamesettings.jumpHeight * -3.0f * gamesettings.gravityValue);
        }

        //forces player on the ground
        playerVelocity.y += gamesettings.gravityValue * Time.deltaTime;
        playerController.Move(playerVelocity * Time.deltaTime);

        if (running)
        {
            float startTime = Time.time;

            //lets the player run
            if (Time.time < startTime + runTime)
            {
                playerController.Move(transform.TransformDirection(_move.x, 0, _move.z) * Time.deltaTime *
                                      gamesettings.runSpeed);
            }
        }
    }
    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        Vector2 stayStill = new Vector2(0, 0);
        if(move!=stayStill)
        {
            if (timer >= 1)
            {
                switch (audioTurn)
                {
                    case 0:
                        footstepA.GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
                        audioTurn = 1;
                        timer = 0;
                        Debug.Log("Step A");
                        break;
                    case 1:
                        footstepB.GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
                        audioTurn = 0;
                        timer = 0;
                        Debug.Log("Step B");
                        break;
                }
            }
        }
        if (Life <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(3);
        }
    }
    public void GetDmg(int Dmg)
    {
        if (!canNotGetDmg)
        {
            canNotGetDmg = true;
            Life -= Dmg;
            Aktualisier_Life();
            Invoke("boolCanGetDmg", 1);
        }
        if (Life <= 0)
        {
            Life_Text.text = "100/" + 0;
            Lebens_Img.fillAmount = 0;
            //Gameover
        }
    }

    void boolCanGetDmg()
    {
        Debug.Log("kannschadenbekomen");
        canNotGetDmg = false;
    }

    private void Update()
    {
        Move(move);

        foreach (var mLook in mouselook)
        {
            mLook.Look(look);
        }
    }

    public void Aktualisier_Life()
    {
        if (Life_Text != null)
        {
            Life_Text.text = "100/" + Life;
            Lebens_Img.fillAmount = Life / 100f;
        }
    }
}