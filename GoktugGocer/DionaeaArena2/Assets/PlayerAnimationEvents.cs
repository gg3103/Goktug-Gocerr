using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
    private Player player;
    public GameObject CVAttack1Prefab;
    public Transform spawnPosition;



    private void Awake()
    {
        player = GetComponentInParent<Player>();

    }

    private void DisableMovement()
    {
        player.EnableMovement(false);
    }

    private void EnableMovement()
    {
        player.EnableMovement(true);
    }


    public void FireCVAttack1()
    {

        GameObject tempCVAttack1 = Instantiate(CVAttack1Prefab, spawnPosition.position, spawnPosition.rotation);

        tempCVAttack1.GetComponent<Rigidbody2D>().linearVelocity = spawnPosition.right * 10f;


    }


}
