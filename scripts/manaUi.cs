using Godot;

namespace tower_deff.scripts;

public partial class manaUi : Control
{
    private Label _label;
    
    public override void _Ready()
    {
        _label = GetNode<Label>("Label");
    }

    public void Update(int value)
    {
        _label.Text = value.ToString();
    }
}