using UnityEngine;
using UnityEngine;
using System.Collections;

//[AddComponentMenu("Camera-Control/Mouse drag Orbit with zoom")]
public class Cake : MonoBehaviour
{



    public Transform target;

    public Vector3 offset;
    float provo;
    public float distance = 5.0f;
    public float xSpeed = 120.0f;
    public float ySpeed = 120.0f;
    public float zoomSpeed = 20.0f;

    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;

    public float distanceMin = .5f;
    public float distanceMax = 15f;

    public float smoothTime = 2f;

    float rotationYAxis = 0.0f;
    float rotationXAxis = 0.0f;

    float velocityX = 0.0f;
    float velocityY = 0.0f;
    float velocityZoom = 0.0f;
    bool testa;
    Vector3 mPrevPos = Vector3.zero;
    Vector3 mPosDelta = Vector3.zero;
    Vector3 prova;
    // Use this for initialization
    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        rotationYAxis = angles.y;
        rotationXAxis = angles.x;

        prova = transform.up;

        transform.position = transform.position + offset;

    }

    Vector3 test;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mPosDelta = Input.mousePosition - mPrevPos;
            velocityX += xSpeed * Input.GetAxis("Mouse X") * Time.deltaTime;
            velocityY += ySpeed * Input.GetAxis("Mouse Y") * Time.deltaTime;
            var angle = Vector3.Cross(Vector3.up, transform.up);

            if (Mathf.Abs(angle.x) < 0.5f || oppositeSigns((int)provo, (int)velocityY))
            {
                transform.Rotate(Camera.main.transform.right, velocityY, Space.World);

                if (Mathf.Abs(angle.x) < 0.5f)
                {
                    provo = velocityY;
                }
            }
            //Debug.Log(Mathf.Abs(angle.x));
        }
        velocityZoom += ySpeed * Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime;


        if (Vector3.Dot(transform.up, Vector3.up) >= 0)
        {
            transform.Rotate(transform.up, -velocityX, Space.World);
        }
        else
        {
            transform.Rotate(transform.up, velocityX, Space.World);
        }



        velocityX = Mathf.Lerp(velocityX, 0, Time.deltaTime * smoothTime);
        velocityY = Mathf.Lerp(velocityY, 0, Time.deltaTime * smoothTime);
        velocityZoom = Mathf.Lerp(velocityZoom, 0, Time.deltaTime * smoothTime);


        mPrevPos = Input.mousePosition;
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }

    bool oppositeSigns(int x, int y)
    {
        return (x ^ y) < 0;
    }
}