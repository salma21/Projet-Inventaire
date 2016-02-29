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
    using System.ComponentModel.DataAnnotations.Schema;
    public partial class Batiment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Batiment()
        {
            this.Etage = new HashSet<Etage>();
            this.Parc_auto = new HashSet<Parc_auto>();
        }

        public Nullable<int> idOrganisation { get; set; }
        public Nullable<int> idPays { get; set; }
        public Nullable<int> idRegion { get; set; }
        public Nullable<int> idGouvernorat { get; set; }
        public int idDelegation { get; set; }
        public int idBatiment { get; set; }

        [Required(ErrorMessage = "L'adresse est obligatoire")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "L'adresse doit comporter entre 4 et 50 caractéres")]
        [RegularExpression(@"^[a-zA-Z 0-9éèêâùÉÈ]+$", ErrorMessage = "L'adresse est invalide")]
        public string code { get; set; }

        [Required(ErrorMessage = "La désignation est obligatoire")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "La désignation doit contenir entre 3 et 30 caractères")]
        [RegularExpression(@"^[a-zA-Z 0-9éèêâùÉÈ]+$", ErrorMessage = "La désignation est invalide: exemple Batiment 1")]
        public string description { get; set; }

        public virtual Delegation Delegation { get; set; }
        public virtual Organisation Organisation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Etage> Etage { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Parc_auto> Parc_auto { get; set; }
    }
}
