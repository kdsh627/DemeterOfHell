//enum 타입 목록
namespace Types
{
    public enum PlayerState //플레이어 상태
    {
        Idle,
        Walk,
        Attack
    }

    public enum PlayerDirection //플레이어 방향
    {
        RIGHT,
        LEFT,
        UP,
        DOWN
    }
    public enum OptionState //옵션 UI 버튼 눌림 상태
    {
        Graphic,
        Sound,
        Exit
    }

    public enum PlantType //식물 종류
    {
        Rice,
        Attack,
        PowerBuff,
        HPBuff
    }
}

