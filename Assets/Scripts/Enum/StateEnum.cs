using System;

public class StateEnum
{
    //Các Enum chứa các giá trị để gán cho Animation của từng object

    public enum EPlayerState {idle, run, jump, fall, doubleJump, wallSlide, wallJump, dash, throwWeapon};

    public enum EPlantState {idle, attack};

    public enum EPigState {walk, attack};

    public enum ERinoState {idle, attack, hitWall};

    public enum ETrunkState {walk, attack, coolDownAttack};

    public enum ERadishState {flying, gotHit, idle, run};

    public enum EBeeState {idle, attack};

    public enum ENhismState {nonSpikes, spikesIn, spikes, spikesOut};

    public enum EChameleonState {idle, walk, attack};

    public enum EBatState {idle, cellingOut, attack, cellingIn};
}
