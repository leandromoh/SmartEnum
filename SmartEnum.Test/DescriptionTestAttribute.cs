namespace SmartEnum.Test 
{
    using System;

    [AttributeUsage(AttributeTargets.All)]
    public class DescriptionTestAttribute : Attribute 
    {
        public string Description { get; private set; }

        public DescriptionTestAttribute() : this (string.Empty) {    }

        public DescriptionTestAttribute(string description) => this.Description = description;

        public override bool Equals(object obj) =>
            obj == this
            ? true
            : (obj as DescriptionTestAttribute)?.Description == this.Description;

        public override int GetHashCode() => this.Description.GetHashCode();
    }
}