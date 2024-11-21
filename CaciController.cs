using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaciController : MonoBehaviour
{

    public float _moveSpeedCaci = 3.5f; //_moveSpeedSlime
    private Vector2 _CaciDirection; // _slimeDirection
    private Rigidbody2D _CaciRB2D; // _slimeRB2D

    public DetectionController _detectionArea;

    private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _CaciRB2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _CaciDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        if (_detectionArea.detectedObjs.Count > 0)
        {
            _CaciDirection = (_detectionArea.detectedObjs[0].transform.position - transform.position).normalized;

            _CaciRB2D.MovePosition(_CaciRB2D.position + _CaciDirection * _moveSpeedCaci * Time.fixedDeltaTime);

            if (_CaciDirection.x > 0)
            {
                _spriteRenderer.flipX = false;
            }
            else if (_CaciDirection.x < 0)
            {
                _spriteRenderer.flipX = true;
            }
        }
    }
}