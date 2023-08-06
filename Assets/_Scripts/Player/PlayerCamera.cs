using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera
{
    private Player _player = null;
    public Camera playerCamera{get; private set;} = null;
    public float rotationSpeed{get; private set;} = 4f;

    public Vector3 camera3rdPerPos = new Vector3(.75f, .75f, -2.5f);
    public Vector3 camera1stPerPos = new Vector3(0f, .75f, .75f);
    private float _rotationH = 0f;
    private float _rotationV = 0f;
    private float _minAngledClamp = -50f;
    private float _maxAngledClamp = 50f;
    private Quaternion _rotation = Quaternion.identity;

    public PlayerCamera(Player player)
    {
        this._player = player;
    }

    public void InitializeCamera()
    {
        this.playerCamera = Camera.main;
        this.playerCamera.transform.parent = this._player.rotatePoint;
        
        switch(this._player.cameraType)
        {
            case CameraType.FIRSTPERSON:
                this.playerCamera.transform.localPosition = camera1stPerPos;
            break;

            case CameraType.THIRDPERSON:
                this.playerCamera.transform.localPosition = camera3rdPerPos;
            break;

            default:
            Debug.LogError("No Proper Camera type set! Please set Camera Type and try again.");
            this.playerCamera.transform.localPosition = camera1stPerPos;
            break;
        }
    }
    public void Rotation()
    {
        this._rotation = Quaternion.identity;
        this._rotationH += this._player.playerInput.CameraXInput() * this.rotationSpeed;

        this._rotationV -= this._player.playerInput.CameraYInput();
        this._rotationV = ClampCamera(this._rotationV);

        this._rotation = Quaternion.Euler(0, this._rotationH, 0);
        this._player.transform.rotation = Quaternion.Lerp(this._player.transform.rotation, this._rotation, .95f);

        this._rotation = Quaternion.Euler(this._rotationV, this._rotationH, 0);
        this._player.rotatePoint.rotation = Quaternion.Lerp(this._player.rotatePoint.rotation, this._rotation, .95f);
    }
    private float ClampCamera(float angle)
    {
        if (angle < -360)
        {
            angle += 360;
        }

        if (angle > 360)
        {
            angle -= 360;
        }

        return Mathf.Clamp(angle, this._minAngledClamp, this._maxAngledClamp);
    }
}
