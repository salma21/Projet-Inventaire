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

    using System.ComponentModel.DataAnnotations;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    public partial class Achat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Achat()
        {
            this.Bien = new HashSet<Bien>();
            this.Vehicule = new HashSet<Vehicule>();
        }
    
        public int Id_achat { get; set; }
        public int idDelegation { get; set; }
        public int Id_fournisseur { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public Nullable<System.DateTime> Date_livraison { get; set; }

        // [Range(1, 100000, ErrorMessage = "Numéro de livraison invalide")]

        //  [DataType(DataType.Currency)]
        [Required]
        [Range(1, 100000, ErrorMessage = "Le numéro de la facture est invalide")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Le numéro de la facture est invalide")]
        [Column]
        public Nullable<int> Num_facture { get; set; }
        [Required]
        [Range(1, 1000000, ErrorMessage = "Le numéro de commande est invalide")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Le numéro de commande est invalide")]
        [Column]
        public Nullable<int> Num_commande { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public Nullable<System.DateTime> Date_d_achat { get; set; }
        [Required]
        [RegularExpression(@"[0-9]{1,}[.]{0,1}[0-9]{0,3}", ErrorMessage = "Le prix d'achat est invalid")]

        public Nullable<decimal> Prix_d_achat { get; set; }
        [Required]
        [Range(1, 100000, ErrorMessage = "Le numéro de livraison est invalide")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Le numéro de livraison est invalide")]
        [Column]
        public Nullable<int> Num_livraison { get; set; }
    
        public virtual Fournisseur Fournisseur { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bien> Bien { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vehicule> Vehicule { get; set; }
    }
}
