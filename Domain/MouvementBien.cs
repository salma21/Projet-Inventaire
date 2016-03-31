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
    using System.ComponentModel.DataAnnotations;
    public partial class MouvementBien
    {
        public int Id_mouvementB { get; set; }
        public int Id_etage { get; set; }
        [Required(ErrorMessage = "Le champs code à barres est obligatoire")]
        public int Id_bien { get; set; }
        [Required(ErrorMessage = "La désignation est obligatoire")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "La désignation doit comporter entre 2 et 30 caractéres")]
        [RegularExpression(@"^[a-zA-Z 0-9éèêâùÉÈ]+$", ErrorMessage = "La désignation est invalide")]
        public string Nom { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Date dernière affectation est obligatoire")]
        public Nullable<System.DateTime> Date_derniere_affectation { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Date prochaine affectation est obligatoire")]
        public Nullable<System.DateTime> Date_prochaine_affectation { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Date renouvellement pévue est obligatoire")]
        public Nullable<System.DateTime> Date_renouvellement_prevue { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Date retour prévue est obligatoire")]
        public Nullable<System.DateTime> Date_retour_prevue { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Date sortie est obligatoire")]
        public Nullable<System.DateTime> Date_sortie { get; set; }

        public virtual Bien Bien { get; set; }
    }
}
