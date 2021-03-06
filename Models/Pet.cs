//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Vet_Surgery_System.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Pet
    {
        public int P_Id { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> D_O_B { get; set; }
        public Nullable<bool> Gender { get; set; }
        public Nullable<double> Cost { get; set; }
        public string Parent_name { get; set; }
        public string Colour { get; set; }
        public string Notes { get; set; }
        public string Pedigree { get; set; }
        public Nullable<int> Breed_Id { get; set; }
        public Nullable<int> Owner_Id { get; set; }
        public Nullable<int> Treatment_Id { get; set; }
        public Nullable<System.DateTime> Date_Time { get; set; }

        public virtual Breed Breed { get; set; }
        public virtual Owner Owner { get; set; }
        public virtual Treatment Treatment { get; set; }
    }

        public enum Gender
        {
            Male,
            Female
        }
   }
