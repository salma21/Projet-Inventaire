//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Association_49
    {
        public Nullable<int> Dep_idPays { get; set; }
        public Nullable<int> Dep_idRegion { get; set; }
        public Nullable<int> idPays { get; set; }
        public Nullable<int> idRegion { get; set; }
        public Nullable<int> Dep_idGouvernorat { get; set; }
        public Nullable<int> idGouvernorat { get; set; }
        public Nullable<int> idOrganisation { get; set; }
        public Nullable<int> Eta_idDelegation { get; set; }
        public Nullable<int> idBatiment { get; set; }
        public Nullable<int> Id_etage { get; set; }
        public Nullable<int> idDelegation { get; set; }
        public Nullable<int> IdDepot { get; set; }
        public int Id_bien { get; set; }
        public Nullable<int> Per_idPays { get; set; }
        public Nullable<int> Per_idRegion { get; set; }
        public Nullable<int> Per_idGouvernorat { get; set; }
        public Nullable<int> Per_idOrganisation { get; set; }
        public Nullable<int> Per_idDelegation { get; set; }
        public Nullable<int> Per_idBatiment { get; set; }
        public int id { get; set; }
    
        public virtual Bien Bien { get; set; }
    }
}