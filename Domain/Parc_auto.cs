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
    
    public partial class Parc_auto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Parc_auto()
        {
            this.Vehicule = new HashSet<Vehicule>();
        }
    
        public Nullable<int> idPays { get; set; }
        public Nullable<int> idRegion { get; set; }
        public Nullable<int> idGouvernorat { get; set; }
        public Nullable<int> idOrganisation { get; set; }
        public Nullable<int> idDelegation { get; set; }
        public int idBatiment { get; set; }
        public int Id_parc { get; set; }
        public string Libelle { get; set; }
    
        public virtual Batiment Batiment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vehicule> Vehicule { get; set; }
    }
}
