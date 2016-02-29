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
    public partial class Delegation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Delegation()
        {
            this.Batiment = new HashSet<Batiment>();
            this.Depot = new HashSet<Depot>();
            this.Fournisseur = new HashSet<Fournisseur>();
        }
    
        public int idPays { get; set; }
        public int idRegion { get; set; }
        public int idGouvernorat { get; set; }
        public int idDelegation { get; set; }
        [Required(ErrorMessage = "Le nom de la délégation est obligatoire")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Le nom de la délégation doit contenir entre 3 et 20 caractères")]
        [RegularExpression(@"^[a-zA-Z 0-9éèêâùÉÈ]+$", ErrorMessage = "Le nom de la délégation  est invalide: exemple Tunis")]
        public string libelle { get; set; }
        [Required(ErrorMessage = "Le code postal est obligatoire")]
        [Range(1000, 9999, ErrorMessage = "Le code postal est invalide")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Le code postal est incorrect : il doit comprendre 4 chiffres")]
        public Nullable<int> Code_postal { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Batiment> Batiment { get; set; }
        public virtual Gouvernorat Gouvernorat { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Depot> Depot { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Fournisseur> Fournisseur { get; set; }
    }
}
