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
    
    public partial class Batiment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Batiment()
        {
            this.Etage = new HashSet<Etage>();
            this.Parc_auto = new HashSet<Parc_auto>();
            this.Personnel = new HashSet<Personnel>();
        }
    
        public Nullable<int> idOrganisation { get; set; }
        public Nullable<int> idPays { get; set; }
        public Nullable<int> idRegion { get; set; }
        public Nullable<int> idGouvernorat { get; set; }
        public int idDelegation { get; set; }
        public int idBatiment { get; set; }
        public Nullable<int> code { get; set; }
        public string description { get; set; }
    
        public virtual Delegation Delegation { get; set; }
        public virtual Organisation Organisation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Etage> Etage { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Parc_auto> Parc_auto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Personnel> Personnel { get; set; }
    }
}
