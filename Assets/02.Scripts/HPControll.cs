using UnityEngine;
public class HPControll : MonoBehaviour
{
    [SerializeField]
    private int HP = 5;

    public void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            Debug.Log("Fail");
        }
    }
}
