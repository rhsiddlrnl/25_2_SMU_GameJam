using UnityEngine;
using UnityEngine.SceneManagement;
public class HPControll : MonoBehaviour
{
    [SerializeField]
    private int HP = 5;
    [SerializeField]
    private HPBarControll hpBarcontroller;

    private void Start()
    {
        hpBarcontroller.SetHPBar(HP);
    }
    public int GetHP()
    {
        return HP;
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
        hpBarcontroller.ClearHPBar();
        hpBarcontroller.SetHPBar(HP);

        if (HP <= 0)
        {
            Debug.Log("Fail");
            GameManager.instance.OnPlayerDead();
        }
    }
}
