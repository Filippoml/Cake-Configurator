using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cake : MonoBehaviour
{

    private bool _mouseEntered;

    [SerializeField]
    private Transform _target;

    [SerializeField]
    private Transform _camera;

    private float _xSpeed;
    private float _ySpeed;

    private float _distanceMin;
    private float _distanceMax;
    private float _smoothTime;
    private float _velocityX;
    private float _velocityY;
    private float _velocityZoom;

    private Vector3 _mPrevPos;
    private Vector3 _mPosDelta;

    private void Awake()
    {
        _distanceMin = 40;
        _distanceMax = 100;
        _smoothTime = 2;
        _xSpeed = 120;
        _ySpeed = 120;
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && _mouseEntered)
        {
            _mPosDelta = Input.mousePosition - _mPrevPos;
            _velocityX += _xSpeed * Input.GetAxis("Mouse X") * Time.deltaTime;
            _velocityY += _ySpeed * Input.GetAxis("Mouse Y") * Time.deltaTime;
        }

        _velocityZoom += Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime;

        if (Vector3.Dot(_target.transform.up, Vector3.up) >= 0)
        {
            _target.transform.Rotate(_target.transform.up, -_velocityX, Space.World);
        }
        else
        {
            _target.transform.Rotate(_target.transform.up, _velocityX, Space.World);
        }

        _target.transform.Rotate(Camera.main.transform.right, _velocityY, Space.World);

        Vector3 zoom = (_target.transform.position - _camera.transform.position) * -_velocityZoom;
        float distance = Vector3.Distance(_target.transform.position + zoom, _camera.transform.position);

        if (Vector3.Distance(_target.transform.position + zoom, _camera.transform.position) < _distanceMax && Vector3.Distance(_target.transform.position + zoom, _camera.transform.position) > _distanceMin)
        {
            _target.transform.position += zoom;
        }
        else
        {
            _velocityZoom = 0;
        }

        _velocityX = Mathf.Lerp(_velocityX, 0.2f, Time.deltaTime * _smoothTime);
        _velocityY = Mathf.Lerp(_velocityY, 0, Time.deltaTime * _smoothTime);
        _velocityZoom = Mathf.Lerp(_velocityZoom, 0, Time.deltaTime * _smoothTime);


        _mPrevPos = Input.mousePosition;
    }

    public void OnMouseEnter()
    {
        _mouseEntered = true;
    }

    public void OnMouseExit()
    {
        _mouseEntered = false;
    }
}