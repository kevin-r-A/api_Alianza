
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
    
public partial class aspnet_Applications
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public aspnet_Applications()
    {

        this.aspnet_Membership = new HashSet<aspnet_Membership>();

        this.aspnet_Paths = new HashSet<aspnet_Paths>();

        this.aspnet_Roles = new HashSet<aspnet_Roles>();

        this.aspnet_Users = new HashSet<aspnet_Users>();

    }


    public string ApplicationName { get; set; }

    public string LoweredApplicationName { get; set; }

    public System.Guid ApplicationId { get; set; }

    public string Description { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<aspnet_Membership> aspnet_Membership { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<aspnet_Paths> aspnet_Paths { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<aspnet_Roles> aspnet_Roles { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<aspnet_Users> aspnet_Users { get; set; }

}

}
