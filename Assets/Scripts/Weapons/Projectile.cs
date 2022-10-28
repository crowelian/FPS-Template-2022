using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float speed = 100f;
    [SerializeField]
    private float acceleration = 0f;
    [SerializeField]
    private int damageAmount = 1;

    /// <summary>
    /// Returns the direction of this projectile
    /// </summary>
    public Vector3 Direction { get; set; }

    /// <summary>
    /// Returns if the projectile is facing right
    /// </summary>
    public bool FacingRight { get; set; }

    /// <summary>
    /// Returns the speed of the projectile
    /// </summary>
    public float Speed { get; set; }

    //public Character ProjectileOwner { get; set; }

    // Internal
    private Rigidbody myRigidbody;
    private Collider collider;
    //private SpriteRenderer spriteRenderer;
    private Vector2 movement;
    private bool canMove;

    private void Awake()
    {
        Speed = speed;
        FacingRight = true;
        canMove = true;

        myRigidbody = GetComponent<Rigidbody>();
        //spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider>();
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            MoveProjectile();
        }
    }

    /// <summary>
    /// Moves this projectile
    /// </summary>
    public void MoveProjectile()
    {
        movement = Direction * (Speed / 10f) * Time.fixedDeltaTime;
        //myRigidbody.MovePosition(myRigidbody.position + movement);
        //myRigidbody.MovePosition(movement);
        myRigidbody.velocity = transform.forward * Speed;
        Speed += acceleration * Time.deltaTime;
    }



    /// <summary>
    /// Set the direction and rotation in order to move
    /// </summary>
    /// <param name="newDirection">New direction</param>
    /// <param name="rotation">Owner rotation</param>
    /// <param name="isFacingRight">Owner flip value</param>
    public void SetDirection(Vector2 newDirection, Quaternion rotation, bool isFacingRight = true)
    {
        Direction = newDirection;

        transform.rotation = rotation;
    }

    public void ResetProjectile()
    {

    }

    public void DisableProjectile()
    {
        canMove = false;
        if (GetComponent<WeaponBullet>())
        {
            GetComponent<WeaponBullet>().weaponBullet.enabled = false;
        }
        collider.enabled = false;
        Debug.Log("here some effect of projectile hit???");
    }

    public void EnableProjectile()
    {
        canMove = true;
        if (GetComponent<WeaponBullet>())
        {
            GetComponent<WeaponBullet>().weaponBullet.enabled = true;
        }
        collider.enabled = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Health>())
        {
            collision.gameObject.GetComponent<Health>().Damage(damageAmount);
        }
        DisableProjectile();
    }
}
