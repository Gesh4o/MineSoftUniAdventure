namespace UniversityLearningSystem.Contracts
{
    public interface IView
    {
        object Model { get; }

        string Display();
    }
}