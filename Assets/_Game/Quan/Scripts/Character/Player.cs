using UnityEngine;

public class Player : MonoBehaviour
{

    private enum Direct
    {
        Right,
        Left,
        Forward,
        Backward,
        None,
    }
    private Vector2 startPos;
    private Vector2 endPos;
    private float angle = 0;
    private float sign = 1;
    private float offset = 1;


    [SerializeField] private GameObject bulletPrefabs;
    [SerializeField] private Transform muzzle;
    [SerializeField] private float speed;
    [SerializeField] private Direct currentDirect = Direct.None;

    private bool isDelayFire = false;
    [SerializeField] private float timeDelay;
    [SerializeField] private float timeToNextFire;


    private Rigidbody rb;

    private Vector3 directionMove;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        directionMove = Vector3.forward;


    }

    private void Update()
    {
        Move();
        if (isDelayFire == true)
        {
            timeToNextFire -= Time.deltaTime;
            if (timeToNextFire <= 0)
            {
                isDelayFire = false;
            }
        }
    }

    protected void Move()
    {
        SetDirectionMove();
        SetRotation();
        rb.velocity = new Vector3(directionMove.x * speed, rb.velocity.y, directionMove.z * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
            {
                if (isDelayFire == false)
                {
                    Attack();
                    isDelayFire = true;
                    timeToNextFire = timeDelay;
                }
            }
        }
    }

    protected void SetRotation()
    {
        transform.rotation = Quaternion.LookRotation(directionMove);
    }

    protected void Attack()
    {
        GameObject bullet = Instantiate(bulletPrefabs);
        Bullet b = bullet.GetComponent<Bullet>();
        bullet.transform.position = muzzle.position;
        bullet.transform.rotation = Quaternion.LookRotation(transform.forward);

        b.direction = directionMove;

    }
    protected void SetDirectionMove()
    {
        GetTouchDirection();
        switch (currentDirect)
        {
            case Direct.Left:
                directionMove = Vector3.left;
                break;
            case Direct.Right:
                directionMove = Vector3.right;
                break;
            case Direct.Forward:
                directionMove = Vector3.forward;
                break;
            case Direct.Backward:
                directionMove = Vector3.back;
                break;
        }
    }
    protected void GetTouchDirection()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                startPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {

                endPos = touch.position;
                Vector2 swipeTouch = endPos - startPos;
                sign = (swipeTouch.y >= 0) ? 1 : -1;
                offset = (sign >= 0) ? 0 : 360;
                angle = Vector2.Angle(Vector2.right, swipeTouch) * sign + offset;
                Debug.Log(swipeTouch.magnitude);
                if (swipeTouch.magnitude >= 300)
                {

                    if (angle <= 45 || angle > 315)
                    {
                        //Right
                        currentDirect = Direct.Right;
                    }
                    if (angle > 45 && angle <= 135)
                    {
                        //Foward
                        currentDirect = Direct.Forward;

                    }
                    if (angle > 135f && angle <= 225)
                    {
                        //Left
                        currentDirect = Direct.Left;

                    }
                    if (angle > 225f && angle <= 315f)
                    {
                        //Back
                        currentDirect = Direct.Backward;
                    }
                }
            }
        }

    }
}
