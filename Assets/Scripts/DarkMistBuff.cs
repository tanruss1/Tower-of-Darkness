using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkMistBuff : MonoBehaviour
{
    [SerializeField]
    public int Attack = 5;
    public int AttackBuff = 2;
    public int BuffTime = 10;
    public bool AttackUp;

    public void SpeedUpEnabled()
    {
        AttackUp = true;
        Attack *= AttackBuff;
        StartCoroutine(SpeedUpDisableRoutine());
    }

    IEnumerator SpeedUpDisableRoutine()
    {
        yield return new WaitForSeconds(3.0f);

        Attack /= AttackBuff;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Minion"))
        {
            SpeedUpEnabled();
            Destroy(this.gameObject);
        }
    }
}
