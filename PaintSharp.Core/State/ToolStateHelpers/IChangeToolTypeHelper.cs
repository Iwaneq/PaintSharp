namespace PaintSharp.Core.State.ToolStateHelpers
{
    public interface IChangeToolTypeHelper
    {
        void ChangeToPen();
        void ChangeToEraser();
        void ChangeToSpray();
        void ChangeToFloodFill();
    }
}