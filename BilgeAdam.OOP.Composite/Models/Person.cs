using BilgeAdam.OOP.Composite.Enums;
using System;
using System.Collections.Generic;

namespace BilgeAdam.OOP.Composite.Models
{
    public sealed class Person
    {
        private Lazy<List<Person>> lazy = new Lazy<List<Person>>();
        private bool hasChildren;
        public Person(string fullName, Gender gender, int level = 0)
        {
            FullName = fullName;
            Gender = gender;
            Level = level;
        }
        
        public string FullName { get; set; }
        public Gender Gender { get; set; }
        public int Level { get; set; }
        public Person Parent { get; set; }
        public bool HasChildren { get { return hasChildren; } }
        public IReadOnlyList<Person> Children
        {
            get
            {
                return lazy.Value.AsReadOnly();
            }
        }

        public void AddChild(Person child)
        {
            if (child.GetHashCode() == this.GetHashCode())
            {
                return;
            }
            hasChildren = true;
            child.Parent = this;
            child.Level = Level + 1;
            lazy.Value.Add(child);
        }

        public void AddChildren(params Person[] children)
        {
            foreach (var child in children)
            {
                AddChild(child);
            }
        }
    }
}
