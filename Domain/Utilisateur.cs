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
    
    public partial class Utilisateur
    {
        public int id { get; set; }
        public int idBatiment { get; set; }
        public int Per_id { get; set; }
        public string login { get; set; }
        public string motDePasse { get; set; }
        public Nullable<bool> etatUtilisateur { get; set; }
    }
}
