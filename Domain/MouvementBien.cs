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
    
    public partial class MouvementBien
    {
        public int Id_mouvementB { get; set; }
        public int Id_etage { get; set; }
        public int Id_bien { get; set; }
        public string Nom { get; set; }
        public Nullable<System.DateTime> Date_derniere_affectation { get; set; }
        public Nullable<System.DateTime> Date_prochaine_affectation { get; set; }
        public Nullable<System.DateTime> Date_renouvellement_prevue { get; set; }
        public Nullable<System.DateTime> Date_retour_prevue { get; set; }
        public Nullable<System.DateTime> Date_sortie { get; set; }
    
        public virtual Bien Bien { get; set; }
    }
}
