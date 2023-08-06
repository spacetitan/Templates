using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor
{
    private Player _player = null;

    public float _speed{get; private set;} = 6f;
    public float _jumpForce{get; private set;} = 5f;
    public float _gravity{get; private set;} = 9.8f; //Standard Gravity 9.8f

    private Vector3 _direction = Vector3.zero;
    private Vector3 _moveVelocity = Vector3.zero;

    private float _yVelocity = 0.0f;

    public PlayerMotor(Player player)
    {
        this._player = player;
    }

    public void Movement()
    {
        if(this._speed < 0)
        {
            this._speed = 0;
        }

        Jumping();

        this._direction = (this._player.playerInput.MovementXInput() * this._player.transform.right) + (this._player.playerInput.MovementZInput() * this._player.transform.forward);
        this._direction.Normalize();

        this._moveVelocity = this._direction * this._speed;
        this._moveVelocity.y = this._yVelocity;

        this._player.playerCharCon.Move(this._moveVelocity * Time.smoothDeltaTime);
        
        if(this._direction != Vector3.zero)
        {
            this._player.isMoving = true;
        }
        else
        {
            this._player.isMoving = false;
        }
    }

    public void Jumping()
    {
        if(this._player.isGrounded)
        {
            if(this._player.playerInput.JumpInput())
            {
                this._yVelocity = this._jumpForce;
            }
        }
        else
        {
            this._yVelocity -= this._gravity * Time.smoothDeltaTime;
            if (this._yVelocity < -this._gravity)
            {   
                this._yVelocity = -this._gravity;
            }
        }
        
    }
}
