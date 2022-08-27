namespace CarGame.Enviroment
{
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
    public static class GamingControl
    {
        private static readonly ControlInput controlInput = new();

        public static IReadOnlyList<InputValue> Inputs(ControlType controlType) => controlInput.Inputs(controlType);

        public static void Input_KeyDown(object? sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    e.SuppressKeyPress = true;
                    controlInput.SetInput(ControlType.A, InputValue.Left, true);
                    break;
                case Keys.D:
                    e.SuppressKeyPress = true;
                    controlInput.SetInput(ControlType.A, InputValue.Right, true);
                    break;
                case Keys.S:
                    e.SuppressKeyPress = true;
                    controlInput.SetInput(ControlType.A, InputValue.Backward, true);
                    break;
                case Keys.W:
                    e.SuppressKeyPress = true;
                    controlInput.SetInput(ControlType.A, InputValue.Foward, true);
                    break;
                case Keys.Left:
                    e.SuppressKeyPress = true;
                    controlInput.SetInput(ControlType.B, InputValue.Left, true);
                    break;
                case Keys.Right:
                    e.SuppressKeyPress = true;
                    controlInput.SetInput(ControlType.B, InputValue.Right, true);
                    break;
                case Keys.Down:
                    e.SuppressKeyPress = true;
                    controlInput.SetInput(ControlType.B, InputValue.Backward, true);
                    break;
                case Keys.Up:
                    e.SuppressKeyPress = true;
                    controlInput.SetInput(ControlType.B, InputValue.Foward, true);
                    break;
            }            
        }

        public static void Input_KeyUp(object? sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    e.SuppressKeyPress = true;
                    controlInput.SetInput(ControlType.A, InputValue.Left, false);
                    break;
                case Keys.D:
                    e.SuppressKeyPress = true;
                    controlInput.SetInput(ControlType.A, InputValue.Right, false);
                    break;
                case Keys.S:
                    e.SuppressKeyPress = true;
                    controlInput.SetInput(ControlType.A, InputValue.Backward, false);
                    break;
                case Keys.W:
                    e.SuppressKeyPress = true;
                    controlInput.SetInput(ControlType.A, InputValue.Foward, false);
                    break;
                case Keys.Left:
                    e.SuppressKeyPress = true;
                    controlInput.SetInput(ControlType.B, InputValue.Left, false);
                    break;
                case Keys.Right:
                    e.SuppressKeyPress = true;
                    controlInput.SetInput(ControlType.B, InputValue.Right, false);
                    break;
                case Keys.Down:
                    e.SuppressKeyPress = true;
                    controlInput.SetInput(ControlType.B, InputValue.Backward, false);
                    break;
                case Keys.Up:
                    e.SuppressKeyPress = true;
                    controlInput.SetInput(ControlType.B, InputValue.Foward, false);
                    break;
            }            
        }
    }
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
}
