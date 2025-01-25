using System;
using System.Threading.Tasks;
using Godot;

public partial class PlayerController : Node2D
{

	[Export] public CharacterBody2D HumanForm { get; set; }
	[Export] public CharacterBody2D BallForm { get; set; }

	public IFormController HumanController { get; private set; }
	public IFormController BallController { get; private set; }

	public IFormController ActiveController { get; private set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

		foreach (var action in InputMap.GetActions())
		{
			GD.Print(action);
		}
		HumanController = HumanForm as IFormController;
		BallController = BallForm as IFormController;

		// HumanController.Parent = this;
		// BallController.Parent = this;

		ActiveController = HumanController;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
		// System.Console.WriteLine(delta);
		var movementInput = ProcessInputs();
		
		ActiveController.ProcessMovement(delta, movementInput);
    }

    private MovementInput ProcessInputs()
	{
		var movementInput = MovementInput.INPUT_NONE;
		
		movementInput |= Input.IsActionJustPressed("INPUT_JUMP") ? MovementInput.INPUT_JUMP : 0; 
		movementInput |= Input.IsActionJustPressed("INPUT_MORPH") ? MovementInput.INPUT_MORPH : 0;

		movementInput |= Input.IsActionPressed("INPUT_UP") 		? MovementInput.INPUT_UP : 0;
		movementInput |= Input.IsActionPressed("INPUT_RIGHT") 	? MovementInput.INPUT_RIGHT : 0;
		movementInput |= Input.IsActionPressed("INPUT_DOWN") 	? MovementInput.INPUT_DOWN : 0;
		movementInput |= Input.IsActionPressed("INPUT_LEFT") 	? MovementInput.INPUT_LEFT : 0;

		return movementInput;
	}

	private void Morph()
	{

	} 
}
