using BilgeAdam.OOP.App.Models;
using BilgeAdam.OOP.Composite.App.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilgeAdam.OOP.App
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            var root = LoadHierarchy();
            var parentNode = trvFamily.Nodes.Add(root.FullName);
            LoadTree(parentNode, root);
            parentNode.Expand();
        }

        private void LoadTree(TreeNode parent, Person root)
        {
            if (root.HasChildren)
            {
                foreach (var child in root.Children)
                {
                    var childNode = parent.Nodes.Add(child.FullName);
                    LoadTree(childNode, child);
                    childNode.Expand();
                }
            }
        }

        private static Person LoadHierarchy()
        {
            var person = new Person("Ahmet Yıldız", Gender.Male);
            var c1 = new Person("Güliz Ayla", Gender.Female);
            var c2 = new Person("Gülay Demir", Gender.Female);
            person.AddChild(c1);
            person.AddChild(c2);
            var c11 = new Person("Ayla Perk", Gender.Female);
            var c12 = new Person("Ferhat Ayla", Gender.Male);
            var c13 = new Person("Serhat Ayla", Gender.Male);
            c1.AddChildren(c11, c12, c13);
            var c22 = new Person("Cenk Demir", Gender.Male);
            var c23 = new Person("Berk Demir", Gender.Male);
            c2.AddChildren(c22, c23);
            var c111 = new Person("Can Perk", Gender.Male);
            var c112 = new Person("Canan Perk", Gender.Female);
            c11.AddChildren(c111, c112);

            return person;
        }
    }
}
