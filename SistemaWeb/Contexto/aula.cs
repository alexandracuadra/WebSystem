//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SistemaWeb.Contexto
{
    using System;
    using System.Collections.Generic;
    
    public partial class aula
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public aula()
        {
            this.horarios = new HashSet<horario>();
        }
    
        public int cod_aula { get; set; }
        public string nombre { get; set; }
        public string ubicasion { get; set; }
        public string ac { get; set; }
        public int capacidad { get; set; }
        public Nullable<int> n_equipo { get; set; }
        public int cod_tipoaula { get; set; }
        public int cod_dpto { get; set; }
    
        public virtual dpto dpto { get; set; }
        public virtual tipoaula tipoaula { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<horario> horarios { get; set; }
    }
}