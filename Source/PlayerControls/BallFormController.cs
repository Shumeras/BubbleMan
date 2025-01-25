using System.Threading.Tasks;
using Godot;

public partial class BallFormController : CharacterBody2D, IFormController
{
    public bool IsActive { get; set; }
    public bool IsMorphing { get; set; }
    public Node2D Parent { get; set; }

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
        throw new System.NotImplementedException();
    }
}