using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameData GameData;
    public SoundManager SoundManager;

    public PlayerManager PlayerManager;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject); // 씬 전환 시 유지
    }

    private void Start()
    {
        PlayerManager = PlayerManager.Instance;//게임매니저에서도 접근할 수 있게 해둠. (플레이어 레벨이나 플레이어의 현재 공격력, 플레이어가 획득한 경험치 등에 접근하기 위함)
    }
}

