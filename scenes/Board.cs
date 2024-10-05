using Godot;

public partial class Board : TileMap
{
	private readonly int ORIGINAL_SIZE_BOARD = 1024;

	public override void _Ready()
	{
		ResizeBoard();
		CentralizeBoard();
	}

	public override void _Process(double delta)
	{
		ResizeBoard();
		CentralizeBoard();
    }

    private void ResizeBoard()
	{
		var boardScale = new Vector2(GetBoardSideScale(), GetBoardSideScale());
		Scale = boardScale;
	}

    private void CentralizeBoard()
		=> Position = new Vector2(GetBoardXPositionToCentralizeBoard(), 0);

	private float GetBoardSideScale()
		=> GetWindowSize().Y / ORIGINAL_SIZE_BOARD;

	private float GetBoardXPositionToCentralizeBoard()
		=> GetWindowSize().X / 2 - GetBoardSideScale() * ORIGINAL_SIZE_BOARD / 2;

	private Vector2 GetWindowSize()
		=> GetViewportRect().Size;
}