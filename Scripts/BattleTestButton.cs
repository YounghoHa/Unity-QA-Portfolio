using UnityEngine;

public class BattleTestButton : MonoBehaviour
{
    [Header("테스트 수치")]
    [SerializeField] float m_healValue = 9999.0f;
    [SerializeField] int m_attackBuffValue = 30;
    [SerializeField] int m_attackBuffTurn = 1;

    /// <summary>
    /// 테스트 버튼용: 플레이어 현재 체력 회복
    /// </summary>
    public void OnClickHeal()
    {
        GameSet _gameSet = GetGameSet();

        if (_gameSet == null)
        {
            Debug.LogWarning("[BattleTestButton] GameSet을 찾지 못했습니다.");
            return;
        }

        _gameSet.Heal(m_healValue);

        Debug.Log($"[BattleTestButton] 체력 회복 테스트 / 회복량:{m_healValue}");
    }

    /// <summary>
    /// 테스트 버튼용: 공격력 강화
    /// </summary>
    public void OnClickAttackBuff()
    {
        GameSet _gameSet = GetGameSet();

        if (_gameSet == null)
        {
            Debug.LogWarning("[BattleTestButton] GameSet을 찾지 못했습니다.");
            return;
        }

        _gameSet.ApplyAttackBuff(m_attackBuffValue, m_attackBuffTurn);

        Debug.Log($"[BattleTestButton] 공격력 강화 테스트 / 강화:{m_attackBuffValue} / 턴:{m_attackBuffTurn}");
    }

    GameSet GetGameSet()
    {
        if (GManager.Instance != null &&
            GManager.Instance.IsGameSet != null)
        {
            return GManager.Instance.IsGameSet;
        }

        if (GameSet.Instance != null)
        {
            return GameSet.Instance;
        }

        return FindObjectOfType<GameSet>();
    }
}
