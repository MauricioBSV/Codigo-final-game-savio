using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{


    private Rigidbody2D _playerRigidbody2d;
    private Animator _playeranimator;
    public float _playerSpeed;
    private float _playerInitialSpeed;
    public float _playerRunSpeed;
    private Vector2 _playerDirection;

    private bool _isAttack = false;

    // Start is called before the first frame update
    void Start()
    {
        _playerRigidbody2d = GetComponent<Rigidbody2D>();
        _playeranimator = GetComponent<Animator>();

        _playerInitialSpeed = _playerSpeed;

    }

    // Update is called once per frame
    void Update()
    {


        // Flip();

        PlayerRun();

        OnAttack();

        Flip(); 

    }

    void FixedUpdate()
    {
        _playerDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (_playerDirection.sqrMagnitude > 0.1)
        {

            MovePlayer();

            _playeranimator.SetFloat("AxisX", _playerDirection.x);
            _playeranimator.SetFloat("AxisY", _playerDirection.y);

            _playeranimator.SetInteger("Movimento", 1);
        }
        else
        {
            _playeranimator.SetInteger("Movimento", 0);
        }

        if (_isAttack) // verdadeira
        {
            _playeranimator.SetInteger("Movimento", 2);
        }
    }

    void MovePlayer()
    {
        _playerRigidbody2d.MovePosition(_playerRigidbody2d.position + _playerDirection.normalized * _playerSpeed * Time.fixedDeltaTime);
    }

    void Flip()
    {
        if (_playerDirection.x > 0)
        {
            transform.eulerAngles = new Vector2(0f, 0f);
        }
        else if (_playerDirection.x < 0)
        {
            transform.eulerAngles = new Vector2(0f, 180f);
        }
    }

    void PlayerRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _playerSpeed = _playerRunSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _playerSpeed = _playerInitialSpeed;
        }
    }

    void OnAttack()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetMouseButtonDown(0))
        {
            _isAttack = true;
            _playerSpeed = 0;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetMouseButtonUp(0))
        {
            _isAttack = false;
            _playerSpeed = _playerInitialSpeed;
        }
    }
}