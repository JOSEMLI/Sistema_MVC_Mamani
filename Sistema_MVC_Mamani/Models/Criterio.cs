namespace Sistema_MVC_Mamani.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    using System.Linq;
    using System.Data.Entity;

    [Table("Criterio")]
    public partial class Criterio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Criterio()
        {
            Actividad = new HashSet<Actividad>();
            ControlAsignacion = new HashSet<ControlAsignacion>();
            DetalleAsignacion = new HashSet<DetalleAsignacion>();
            EvidenciaCriterio = new HashSet<EvidenciaCriterio>();
        }

        [Key]
        public int criterio_id { get; set; }

        public int modelo_id { get; set; }

        [Required]
        [StringLength(250)]
        public string nombre_spanish { get; set; }

        [Required]
        [StringLength(250)]
        public string nombre_english { get; set; }

        [StringLength(250)]
        public string urlcriterio { get; set; }

        [Column(TypeName = "text")]
        public string descripcion { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Actividad> Actividad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ControlAsignacion> ControlAsignacion { get; set; }

        public virtual Modelo Modelo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleAsignacion> DetalleAsignacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EvidenciaCriterio> EvidenciaCriterio { get; set; }




        //metodo listar

        public List<Criterio> listar() //retorna una coleccion de resgistro
        {
            var objcriterio = new List<Criterio>();

            try
            {

                using (var db = new modelo_sistemas())
                {
                    objcriterio = db.Criterio.Include("modelo").Include("detalleasignacion").ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objcriterio;
        }



        //metodo obtener

        public Criterio obtener(int id) //retorna solo un objeto
        {
            var objcriterio = new Criterio();

            try
            {
                using (var db = new modelo_sistemas())
                {
                    objcriterio = db.Criterio.Include("modelo").Where(x => x.criterio_id == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return objcriterio;
        }


        // metodo guardar

        public void guardar()
        {

            try
            {
                using (var db = new modelo_sistemas())
                {
                    if (this.criterio_id > 0)
                    {
                        //si existe un valor mayor a cero es porque exiiste el registro
                        db.Entry(this).State = EntityState.Modified;

                    }
                    else
                    {
                        //si no existe el registro lo graba(nuevo)
                        db.Entry(this).State = EntityState.Added;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //metodo eliminar

        public void eliminar()
        {
            try
            {
                using (var db = new modelo_sistemas())
                {
                    db.Entry(this).State = EntityState.Deleted;
                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }



    }
}
