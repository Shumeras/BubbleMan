using System.Threading.Tasks;
using Godot;


public interface IFormController
{
    public bool IsActive { get; set; }
    public bool IsMorphing { get; set; }
    public Node2D Parent { get; set; }

    public Task Morph();
    public Task Die();
    public void ProcessMovement(double delta, MovementInput input);
    public Task Activate();
    public Task Deactivate(); 

}