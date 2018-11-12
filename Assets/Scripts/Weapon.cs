using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float fireRate = 0;
    public float Damage = 10;
    public LayerMask whatToHit;

    public Transform ArrowTrailPrefab;

    private Vector2 direction;
    private Vector2 direction2;

    Transform firePoint;
    Lock_On _lockOn;


	// Use this for initialization
	void Awake ()
    {
        firePoint = transform.Find("FirePoint");
        if (firePoint == null)
        {
            Debug.LogError("FirePoint not found. Check inspector.");
        }
        _lockOn = FindObjectOfType<Lock_On>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (fireRate == 0)
        {
            if (Input.GetKey(KeyCode.W))
            {
                Shoot();
            }
            else
            {
                return;
            }
        }
    }

    public void Shoot()
    {
        float enemyX = _lockOn.targetX;
        float enemyY = _lockOn.targetY;

        //float angle;
        float angle2;
        //Vector3 mousePosition = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 
        //                            Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        Vector3 enemyPosition = new Vector3(enemyX, enemyY, 0);
        Vector3 firePointPosition = new Vector3(firePoint.position.x, firePoint.position.y, 0);

        

        //mousePosition.x = mousePosition.x - firePointPosition.x;
        //mousePosition.y = mousePosition.y - firePointPosition.y;
        enemyPosition.x = enemyPosition.x - firePointPosition.x;
        enemyPosition.y = enemyPosition.y - firePointPosition.y;

        //angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
        angle2 = Mathf.Atan2(enemyPosition.y, enemyPosition.x) * Mathf.Rad2Deg;

        //firePoint.rotation = Quaternion.Euler(0, 0, angle);
        firePoint.rotation = Quaternion.Euler(0, 0, angle2);

        //direction = mousePosition - firePointPosition;
        direction2 = enemyPosition - firePointPosition;

        //RaycastHit2D hit = Physics2D.Raycast(firePointPosition, direction, 100, whatToHit);
        //Effect();
        RaycastHit2D hit2 = Physics2D.Raycast(firePointPosition, direction2, 100, whatToHit);
        Effect2();

        //Debug.DrawLine(firePointPosition, direction * 100, Color.cyan);
        //Debug.DrawLine(firePointPosition, direction2 * 100, Color.cyan);

        //if (hit.collider != null)
        //{
            //Debug.DrawLine(firePointPosition, hit.point, Color.red);
        //}

        if (hit2.collider != null)
        {
            Debug.DrawLine(firePointPosition, hit2.point, Color.red);
        }
    }

    void Effect()
    {
        Instantiate(ArrowTrailPrefab, firePoint.position, firePoint.rotation);
        //Debug.Log("direction = " + direction);
    }

    void Effect2()
    {
        Instantiate(ArrowTrailPrefab, firePoint.position, firePoint.rotation);
        //Debug.Log("direction = " + direction2);
    }
}
