using System.Threading.Tasks;
using Godot;

public partial class HumanFormController : CharacterBody2D, IFormController
{
    public bool IsActive { get; set; }
    public bool IsMorphing { get; set; }
    public Node2D Parent { get; set; }
   
    [Export] public float JumpForce { get; set; } = 400f;      
    [Export] public float Gravity { get; set; } = 800f;        
    [Export] public int MaxJumps { get; set; } = 1;            

    [Export] public float Acceleration { get; set; } = 600f;  
    [Export] public float Friction { get; set; } = 400f;
    [Export] public float AirFriction{ get; set; } = 10f;
    [Export] public float MaxSpeed { get; set; } = 250f;   
    
    private int jumpCount = 0;                   
    private Vector2 velocity = Vector2.Zero;

    public Task Die()
    {
        throw new System.NotImplementedException();
    }

    public Task Morph()
    {
        throw new System.NotImplementedException();
    }

    public Task Activate()
    {
        throw new System.NotImplementedException();
    }

    public Task Deactivate()
    {
        throw new System.NotImplementedException();
    }

    public void ProcessMovement(double delta, MovementInput input)
    {
        float deltaTime = (float)delta;

        if (!IsOnFloor())
        {
            velocity.Y += Gravity * deltaTime;
        }
        else
        {
            jumpCount = 0; 
        }

        // if((input & (MovementInput.INPUT_RIGHT | MovementInput.INPUT_LEFT)) > 0)
        // {
        //     input &= MovementInput.INPUT_ALL ^ (MovementInput.INPUT_RIGHT | MovementInput.INPUT_LEFT);   
        // }

        // if((input & (MovementInput.INPUT_UP | MovementInput.INPUT_DOWN)) > 0)
        // {
        //     input &= MovementInput.INPUT_ALL ^ (MovementInput.INPUT_UP | MovementInput.INPUT_DOWN);   
        // }

        float xAcceleration = 0;
        xAcceleration += (input & MovementInput.INPUT_RIGHT) > 0 ? 1 : 0; 
        xAcceleration += (input & MovementInput.INPUT_LEFT) > 0 ? -1 : 0; 

        if (xAcceleration != 0)
        {
            if (Mathf.Sign(velocity.X) == xAcceleration && Mathf.Abs(velocity.X) >= MaxSpeed)
            {
                velocity.X += xAcceleration * Acceleration * deltaTime;
            }
            else
            {
                velocity.X += xAcceleration * Acceleration * deltaTime;
            }
        }
        else
        {
            if(IsOnFloor())
            {
                velocity.X = Mathf.MoveToward(velocity.X, 0, Friction * deltaTime);
            }
            else
            {
                velocity.X = Mathf.MoveToward(velocity.X, 0, AirFriction * deltaTime);
            }
        }

        // Handle jumping
        if ((input & MovementInput.INPUT_JUMP) > 0 && (IsOnFloor() || jumpCount < MaxJumps))
        {
            velocity.Y = -JumpForce;
            jumpCount++;
        }

        // Apply movement
        Velocity = velocity;
        MoveAndSlide();
    }
}