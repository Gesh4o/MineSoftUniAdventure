namespace SoftUniGameStore.App.BindingModels
{
    using System.Linq;

    public abstract class AbstractBindingModel
    {
        protected AbstractBindingModel()
        {
        }

        public virtual bool IsValid()
        {
            return this.GetType().GetProperties().All(p => p.GetValue(this) != null);
        }
    }
}
