using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    private PlayerController playerController;

    public Rigidbody Rigidbody { get; private set; }
    public Animator Animator { get; private set; }

    float horizontalMovement;
    float verticalMovement;

    bool disableMovement = false;


    private void Awake()
    {

    }

    private void OnEnable()
    {
        GameManager.Instance.AllShapesCollected.AddListener(DisableMovement);
    }

    private void OnDisable()
    {
        GameManager.Instance.AllShapesCollected.RemoveListener(DisableMovement);
    }
    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Animator = GetComponent<Animator>();
        playerController = new PlayerController(new PlayerModel(20), this);
        disableMovement = false;
    }

    private void Update()
    {
        if (!disableMovement) 
        {
            horizontalMovement = Input.GetAxisRaw("Horizontal");
            verticalMovement = Input.GetAxisRaw("Vertical");
        }
        
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {

        playerController.HandleMovement(horizontalMovement, 0f, verticalMovement);
    }

    public void SetPlayerController(PlayerController _playerController)
    {
        this.playerController = _playerController;
    }

    private void OnTriggerEnter(Collider other)
    {
        playerController.Collected(other);
    }

    private void DisableMovement()
    {
        disableMovement = true;
        horizontalMovement = verticalMovement = 0f;
    }
}