using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHealth : CharacterHealth
{
    [SerializeField] PlayerController m_PlayerController;
    private void Reset()
    {
        m_PlayerController = GetComponent<PlayerController>();
    }
    public override void OnDamagedEffect()
    {
        base.OnDamagedEffect();
        m_AnimatorCharacter.ChangeState("damaged");
    }
    protected override void OnDeadEffect()
    {
        base.OnDeadEffect();
        m_PlayerController.SetMovingLock(true);
        m_AnimatorCharacter.ChangeState("dead");
        Invoke(nameof(ResetGame), 1);
    }
    void ResetGame()
    {
        m_PlayerController.SetMovingLock(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
