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
    
    public partial class Societe_assurance
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Societe_assurance()
        {
            this.Contrat_assurance = new HashSet<Contrat_assurance>();
        }
    
        public Nullable<int> idPays { get; set; }
        public Nullable<int> idRegion { get; set; }
        public Nullable<int> idGouvernorat { get; set; }
        public int idDelegation { get; set; }
        public int Id_societe_assurance { get; set; }
        public string Libelle { get; set; }
        public string Rue { get; set; }
        public Nullable<int> Tel { get; set; }
        public Nullable<int> Fax { get; set; }
        public string Email { get; set; }
        public string Commentaire { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrat_assurance> Contrat_assurance { get; set; }
        public virtual Delegation Delegation { get; set; }
    }
}
