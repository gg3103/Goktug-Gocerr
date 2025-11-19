using UnityEngine;

public class CVAttack1 : MonoBehaviour
{
    public Collider2D[] player2Colliders;
    [Header("Attack details")]
    [SerializeField] private float attack1Radius;
    [SerializeField] private Transform attack1Point;
    [SerializeField] private LayerMask whatIsEnemy;

    public float CVAttack1Speed = 2f;

    private void Start()
    {
        Destroy(this.gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & whatIsEnemy) != 0)
            DamageEnemies();
    }


    public void DamageEnemies()
    {

        player2Colliders = Physics2D.OverlapCircleAll(attack1Point.position, attack1Radius, whatIsEnemy);

        foreach (var hit in player2Colliders)
        {
            Debug.Log(gameObject.name + "Hasar aldýn.");
            //Hasar verme kodu buraya olacakmis

        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attack1Point.position, attack1Radius);
    }

}
