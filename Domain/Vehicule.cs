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
    
    public partial class Vehicule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vehicule()
        {
            this.MouvementVehicule = new HashSet<MouvementVehicule>();
        }
    
        public Nullable<int> idPays { get; set; }
        public Nullable<int> idRegion { get; set; }
        public Nullable<int> idGouvernorat { get; set; }
        public Nullable<int> idOrganisation { get; set; }
        public Nullable<int> idDelegation { get; set; }
        public Nullable<int> idBatiment { get; set; }
        public int Id_parc { get; set; }
        public int Id_Vehicule { get; set; }
        public Nullable<int> Id_achat { get; set; }
        public string Matricule { get; set; }
        public string Modele { get; set; }
        public string Etat { get; set; }
        public string Num_chassis { get; set; }
        public double Prix_d_achat { get; set; }
        public Nullable<System.DateTime> Annee_achat { get; set; }
    
        public virtual Achat Achat { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MouvementVehicule> MouvementVehicule { get; set; }
        public virtual Parc_auto Parc_auto { get; set; }
    }
}
