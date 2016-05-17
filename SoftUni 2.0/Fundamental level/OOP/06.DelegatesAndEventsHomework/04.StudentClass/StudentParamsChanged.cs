using _04.StudentClass;

public delegate void StudentParamChanged(Student student, StudentParamChangedEventAgs eventArgs);

namespace _04.StudentClass
{

    public class StudentParamChangedEventAgs
    {
        public StudentParamChangedEventAgs(object oldValue, object newValue, string propertyName) 
        {
            this.OldValue = oldValue;
            this.NewValue = newValue;
            this.PropertyName = propertyName;
        }

        public object OldValue { get; set; }
        public object NewValue { get; set; }
        public string PropertyName { get; set; }


    }

}
