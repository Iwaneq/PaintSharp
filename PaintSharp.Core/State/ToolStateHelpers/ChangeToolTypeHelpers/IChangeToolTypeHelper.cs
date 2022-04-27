namespace PaintSharp.Core.State.ToolStateHelpers.ChangeToolTypeHelpers
{
    public interface IChangeToolTypeHelper
    {
        void ChangeClickBooleans();
        void ChangeToCircle();
        void ChangeToRect();
        void ChangeToDefault();
    }
}