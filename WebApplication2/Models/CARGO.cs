
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------


namespace WebApplication2.Models
{

using System;
    using System.Collections.Generic;
    
public partial class CARGO
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public CARGO()
    {

        this.CUSTODIOs = new HashSet<CUSTODIO>();

    }


    public int CGO_ID { get; set; }

    public string CGO_NOMBRE { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<CUSTODIO> CUSTODIOs { get; set; }

}

}