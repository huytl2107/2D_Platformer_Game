using Unity.VisualScripting;

public class EnemiesStateFactory
{
    //Sử dụng StateFactory để quản lý State của Enemies
    //Thuận tiện hơn cho việc sử dụng và thêm mới state
    //Thay vì khởi tạo ở các class khác nhau dùng state factory giúp dễ dàng quản lý các state hơn
    
    EnemiesStateManager _context;

    public EnemiesStateFactory(EnemiesStateManager currentContext)
    {
        _context = currentContext;
    }

    //Mushroom
    public EnemiesBaseState MushroomWalk()
    {
        return new MushRoomWalkState(_context, this);
    }

    public EnemiesBaseState MushRoomGotHit()
    {
        return new MushroomGotHitState(_context, this);
    }

    //Plant
    public EnemiesBaseState PlantIdle()
    {
        return new PlantIdleState(_context, this);
    }
    public EnemiesBaseState PlantAttack()
    {
        return new PlantAttackState(_context, this);
    }

    //AngryPig
    public EnemiesBaseState PigWalk()
    {
        return new PigWalkState(_context, this);
    }
    public EnemiesBaseState PigAttack()
    {
        return new PigAttackState(_context, this);
    }
    public EnemiesBaseState PigGotHit()
    {
        return new PigGotHitState(_context, this);
    }

    //Rino
    public EnemiesBaseState RinoIdle()
    {
        return new RinoIdleState(_context, this);
    }
    public EnemiesBaseState RinoAttack()
    {
        return new RinoAttackState(_context, this);
    }
    public EnemiesBaseState RinoHitWall()
    {
        return new RinoHitWallState(_context, this);
    }
    public EnemiesBaseState RinoGotHit()
    {
        return new RinoGotHitState(_context, this);
    }

    //Trunk
    public EnemiesBaseState TrunkWalk()
    {
        return new TrunkWalkState(_context, this);
    }
    public EnemiesBaseState TrunkAttack()
    {
        return new TrunkAttackState(_context, this);
    }
    public EnemiesBaseState TrunkGotHit()
    {
        return new TrunkGotHitState(_context, this);
    }

    //Radish
    public EnemiesBaseState RadishFly()
    {
        return new RadishFlyingState(_context, this);
    }
    public EnemiesBaseState RadishGotHit()
    {
        return new RadishGotHitState(_context, this);
    }
    public EnemiesBaseState RadishIdle()
    {
        return new RadishIdleState(_context, this);
    }
    public EnemiesBaseState RadishWalk()
    {
        return new RadishWalkState(_context, this);
    }

    //BlueBird
    public EnemiesBaseState BirdIdle()
    {
        return new BirdIdleState(_context, this);
    }
    public EnemiesBaseState BirdAttack()
    {
        return new BirdAttackState(_context, this);
    }
    public EnemiesBaseState BirdGotHit()
    {
        return new BirdGotHitState(_context, this);
    }

    //Bee
    public EnemiesBaseState BeeIdle()
    {
        return new BeeIdleState(_context, this);
    }
    public EnemiesBaseState BeeAttack()
    {
        return new BeeAttackState(_context, this);
    }
    public EnemiesBaseState BeeWalk()
    {
        return new BeeWalkState(_context, this);
    }
    public EnemiesBaseState BeeGotHit()
    {
        return new BeeGotHitState(_context, this);
    }

    //Nhism
    public EnemiesBaseState NhismNonSpikes()
    {
        return new NhismNonSpikesState(_context, this);
    }
    public EnemiesBaseState NhismSpikesIn()
    {
        return new NhimsSpikesInState(_context, this);
    }
    public EnemiesBaseState NhismSpikes()
    {
        return new NhimSpikesState(_context, this);
    }
    public EnemiesBaseState NhismSpikeOut()
    {
        return new NhimsSpikesOutState(_context, this);
    }
    public EnemiesBaseState NhismGotHit()
    {
        return new NhismGotHitState(_context, this);
    }
    
    //Chameleon
    public EnemiesBaseState ChameleonIdle()
    {
        return new ChameleonIdleState(_context, this);
    }
    public EnemiesBaseState ChameleonWalk()
    {
        return new ChameleonWalkState(_context, this);
    }
    public EnemiesBaseState ChameleonAttack()
    {
        return new ChameleonAttackState(_context, this);
    }

    //Bat
    public EnemiesBaseState BatIdle()
    {
        return new BatIdleState(_context, this);
    }
    public EnemiesBaseState BatCellingOut()
    {
        return new BatCellingOutState(_context, this);
    }
    public EnemiesBaseState BatAttack()
    {
        return new BatAttackState(_context, this);
    }
    public EnemiesBaseState BatCellingIn()
    {
        return new BatCellingInState(_context, this);
    }
    public EnemiesBaseState BatReturn()
    {
        return new BatReturnState(_context, this);
    }
    public EnemiesBaseState BatGotHit()
    {
        return new BatGotHitState(_context, this);
    }

    //Chicken
    public EnemiesBaseState ChickenIdle()
    {
        return new ChickenIdleState(_context, this);
    }
    public EnemiesBaseState ChickenRun()
    {
        return new ChickenRunState(_context, this);
    }
    public EnemiesBaseState ChickenGotHit()
    {
        return new ChickenGotHitState(_context, this);
    }

    //Duck
    public EnemiesBaseState DuckIdle()
    {
        return new DuckIdleState(_context, this);
    }
    public EnemiesBaseState DuckRun()
    {
        return new DuckRunState(_context, this);
    }
    public EnemiesBaseState DuckJump()
    {
        return new DuckJumpState(_context, this);
    }
    public EnemiesBaseState DuckFall()
    {
        return new DuckFallState(_context, this);
    }
    public EnemiesBaseState DuckGotHit()
    {
        return new DuckGotHitState(_context, this);
    }

    //Bunny
    public EnemiesBaseState BunnyIdle()
    {
        return new BunnyIdleState(_context, this);
    }
    public EnemiesBaseState BunnyRun()
    {
        return new BunnyRunState(_context, this);
    }
    public EnemiesBaseState BunnyJump()
    {
        return new BunnyJumpState(_context, this);
    }
    public EnemiesBaseState BunnyFall()
    {
        return new BunnyFallState(_context, this);
    }

    //Snail
    public EnemiesBaseState SnailWalk()
    {
        return new SnailWalkState(_context, this);
    }
}
