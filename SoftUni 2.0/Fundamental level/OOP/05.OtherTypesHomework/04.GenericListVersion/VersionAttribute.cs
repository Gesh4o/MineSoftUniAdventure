namespace _04.GenericListVersion
{
    using System;

    [AttributeUsage(AttributeTargets.Class |
        AttributeTargets.Interface |
        AttributeTargets.Struct |
        AttributeTargets.Enum | 
        AttributeTargets.Method, 
        AllowMultiple = true)]

    public class VersionAttribute : Attribute
    {
        public byte Minor { get; private set; }
        public byte Major { get; private set; }

        public VersionAttribute(byte major, byte minor)
        {
            this.Major = major;
            this.Minor = minor;
        }
    }
}
