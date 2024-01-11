using System;

public class StateEnum
{
    //Các Enum chứa các giá trị để gán cho Animation của từng object

    public enum EPlayerState {idle, run, jump, fall, doubleJump, wallSlide, wallJump, dash, throwWeapon};

    public enum EPlantState {idle, attack};

    public enum EPigState {walk, attack};

    public enum ERinoState {idle, attack};

    public enum ETrunkState {walk, attack, coolDownAttack};
}
