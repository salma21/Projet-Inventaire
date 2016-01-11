using Domain;
using System.Collections.Generic;

namespace WebApp.Models {
    public class ProdGizWidgetVM {
        public ProdGizWidgetVM(
             IEnumerable<Utilisateur> gList)
        {
           
            gizmoList = gList;
        }

        public IEnumerable<Utilisateur> gizmoList { get; set; }

    }
}